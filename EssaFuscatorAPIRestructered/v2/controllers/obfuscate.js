const FNOBF = require("../functions/obfuscation")
const FNMARIA = require("../functions/mariadb")
const FNWEB = require("../functions/webhooks")
const FNFS = require("../functions/filesystem")
const FNPRINT = require("../functions/print")
const fs = require('fs')
const crypto = require("node:crypto");

const OBFControl = async(req, res, next) => {
	FNPRINT.sPrint(`Received Request`);
    datajsoned = req.body
    if (!req.params.enctype) return res.status(400).end(JSON.stringify({
        error: "You Must Specify The Encryption Parameter"
    }));
    if (!datajsoned.script) return res.status(400).end(JSON.stringify({
        error: "You Must Put A Script In The Request Body"
    }));
    if (!req.headers["essafuscatorapikey"]) return res.status(400).end(JSON.stringify({
        error: "You Must Put An Authorization Header"
    }));
    var encrpytiontype = req.params.enctype
    const script = await datajsoned.script
    const apikey = await req.headers["essafuscatorapikey"]

    if (encrpytiontype == "arabic") {
        encrpytiontype = "1"
    }else if(encrpytiontype == "emoji"){
        encrpytiontype = "0"
    }else{
        return res.status(400).end(JSON.stringify({
            error: "Invalid Type In The Encryption Parameter"
        }));
    }

    var userid
    if (apikey.includes("ESSA-")) {
        userid = apikey.replace("ESSA-", "")
		if (userid == ("" | undefined | null)) return res.status(400).end(JSON.stringify({
            error: "Unknown Error, Refresh If You Are Using The Website!"
        }))
    }else if(apikey.length != 32){
        return res.status(400).end(JSON.stringify({
            error: "Invalid API Key Structure"
        }))
    }else{
        await FNMARIA.CheckAPIKey(apikey, async(valid) => {
            if (valid == false) {
                return res.status(400).end(JSON.stringify({
                    error: "Invalid API Key"
                }))
            }else{
                userid = String(valid)
            }
        })
    }
    var watermark = ""
    if (datajsoned.watermark ){
        watermark = datajsoned.watermark.replace('"', )
    }else{
        watermark = "discord.gg/obfuscate"
    }
    
    const key = new Date().getTime();
    const filepath = `/files/${apikey}-${key}-temp.lua`
    await fs.writeFile(`Obfuscator/${filepath}`, script, async (err) => {
        if (err) {
            FNFS.DeleteSource();
            return res.status(400).end(JSON.stringify({
                error: "FileSystem" + err
            }));
        } else {
            await FNOBF.Obfuscate(filepath,watermark,encrpytiontype, async(obfuscationoutput) => {
                if (obfuscationoutput.includes("EF_ERROR")) {
                    FNFS.DeleteSource();
					FNPRINT.ePrint(`ERROR: User: ${userid} | Type: ${encrpytiontype} | Watermark: ${watermark}`);
                    return res.status(400).end(JSON.stringify({
                        error: obfuscationoutput
                    }));
                } else {
                    await FNOBF.GetScriptID(async(output) => {
                        if (output.error) {
                            FNFS.DeleteSource();
                            return res.status(400).end(JSON.stringify({
                                error: "SID-" + output.error
                            }));
                        }else{ 
                            await FNMARIA.InsertNewScript(output.ID,userid,async(InsertError) => {
                                if (InsertError) {
                                    FNFS.DeleteSource();
                                    return res.status(400).end(JSON.stringify({
                                        error: "SQL Error " + InsertError
                                    }));
                                } else {
                                    var userhash = await crypto.createHash("sha256").update(`${userid}-${watermark}-${Math.floor(new Date().getTime() / 1000)}`).digest('hex');
                                    await FNMARIA.AddToCDN(output.file,userid,userhash, async(success) => {
                                        if (success.url) {
                                            res.status(200).end(JSON.stringify({
                                                cdnlink: success.url,
                                                obfscript: output.file
                                            }));
                                        }else{
                                            FNFS.DeleteSource();
                                            return res.status(400).end(JSON.stringify({
                                                error: "CDN Error " + success.error
                                            }));
                                        }
                                    })
                                    
                                    FNPRINT.sPrint(`ID: ${output.ID} | User: ${userid} | Type: ${encrpytiontype} | Watermark: ${watermark}`);
                                    await FNWEB.SendObfuscatedWebhook(output.ID, watermark,userid,obfuscationoutput)
                                }
                            });
                        }
                        FNFS.DeleteSource();
                    })
                }
            })
        }
    })
};

module.exports = {OBFControl};
FNPRINT.iPrint("Started Obfuscation Controller")
