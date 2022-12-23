const FNWEB = require("../functions/webhooks")
const FNPRINT = require("../functions/print")

const STATControl = async(req, res, next) => {
    await FNWEB.SendStatusMessage(req.headers['cf-connecting-ip']);
    res.status(200).end(JSON.stringify({
        status: "OK"
    }));
};

module.exports = {STATControl};
FNPRINT.iPrint("Started Status Controller")
