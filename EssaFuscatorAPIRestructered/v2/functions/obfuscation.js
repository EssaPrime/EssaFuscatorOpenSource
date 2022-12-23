const {exec} = require('child_process');
const nthline = require('nthline')
const CGINFO = require("../config/info.json")
const fs = require('fs')
module.exports = {

    Obfuscate: async function(path, watermark,encrpytiontype,output) {
        await exec(`"${CGINFO.PCPATH}/Obfuscator/master/EssaFuscator CLI.exe" "${CGINFO.PCPATH}/Obfuscator/${path}" "${watermark.toString()}" true ${encrpytiontype}`, async (err, stdout, stderr) => {
            if (err) {
                output("EF_ERROR: " + stdout+ String(err) )
            }else if (String(stdout).includes("ERR: ")) {
				var errortoret = stdout.split("\n")[5].replace(`...ctered//Obfuscator/${path}`,"").replace("ERR: ", "")
                output("EF_ERROR: " +`temp.lua${errortoret}`)
            }else if (stderr) {
                output("EF_ERROR: " + stderr)
            }else if(stdout){
                output(stdout)
            };
        });
    },

    GetScriptID: async function(output) {
        await fs.readFile(`${CGINFO.PCPATH}/out.lua`, 'utf-8', async (err, data) => {
            if (!err) {
                await nthline(4, `${CGINFO.PCPATH}/out.lua`).then(async (line) => {
                    const cleanid = line.replace("Script ID:", "").replace(/\s+/g, ' ').trim()
                    output({ID: cleanid, file: data})
                });
            }else{
                output({error:err})
            };
        });
    },
    
}