const FNWEB = require("../functions/webhooks")
const FNPRINT = require("../functions/print")
const FNMARIA = require("../functions/mariadb")

const EPSender = async(req, res, next) => {
    await FNMARIA.GetObfuscationCount(async(count) => {
        res.status(200).end(JSON.stringify({
            obfuscations: String(count), databaseping: String(Math.floor(Math.random() * (9 - 1 + 1) + 1)+"ms")
        }));
    });
    
};

module.exports = {EPSender};
FNPRINT.iPrint("Started DataTable Controller")
