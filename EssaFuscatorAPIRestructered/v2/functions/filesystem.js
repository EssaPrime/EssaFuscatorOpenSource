const fs = require('fs');
const fsExtra = require('fs-extra')
const CGINFO = require("../config/info.json")

module.exports = {

    DeleteSource: async function(path) {
        try { fs.unlinkSync(`${CGINFO.PCPATH}/out.lua`) }catch(e){}
        try { fs.unlinkSync(`${CGINFO.PCPATH}/Obfuscator/${path}`) }catch(e){}
        try { fsExtra.emptyDirSync(`${CGINFO.PCPATH}/Obfuscator/files/`) }catch(e){}
    },
    
}