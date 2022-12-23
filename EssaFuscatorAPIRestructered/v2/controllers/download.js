const FNPRINT = require("../functions/print")
const FNMARIA = require("../functions/mariadb")
const fs = require("fs");

const GetFile = async(req, res, next) => {
    if (!req.params.userid) return res.status(400).end(JSON.stringify({
        error: "You Didin't Specify The ID"
    }));
    if (!req.params.userhash) return res.status(400).end(JSON.stringify({
        error: "You Didin't Specify The Unique File Hash"
    }));
    if ((req.params.userhash).length !=  64 ) return res.status(400).end(JSON.stringify({
        error: "Invalid Hash Structure"
    }));
    if (!req.params.realname) return res.status(400).end(JSON.stringify({
        error: "You Didin't Specify The File"
    }));
    var UserID = req.params.userid
    var UserHash = req.params.userhash
    var RealName = req.params.realname

    await FNMARIA.ValidateDownload(UserID,UserHash,RealName,async(status) => {
        if (status == "GOOD") {
            await fs.readFile(`./Obfuscator/CDN/${UserHash}-${RealName}`,"utf8",async(err,tosend) => {
                if (err) {
                    return res.status(400).end(JSON.stringify({
                        error: "FS"+ err
                    }))
                }
                if (req.query.json == "false") {
                    res.setHeader('Content-disposition', `attachment; filename=EssaFuscatorCDN-${UserHash}.lua`);
                    res.download(`./Obfuscator/CDN/${UserHash}-${RealName}`)
                    return res.status(200).end(tosend);
                }else{
                    return res.status(200).end(JSON.stringify({
                        File: tosend
                    }));
                }
                
            })
        }else if(status == "EXPIRED"){
            return res.status(400).end(JSON.stringify({
                error: "The File Expired"
            }));
        }else if(status == "UNKNOWN"){
            return res.status(400).end(JSON.stringify({
                error: "The File Was Not Found"
            }));
        }
    })
};

module.exports = {GetFile};
FNPRINT.iPrint("Started Download Controller")
