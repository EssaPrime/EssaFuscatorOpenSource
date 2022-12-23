const CNINFO = require('../controllers/inforoute'); 
const FNPRINT = require("../functions/print")
const express = require("express")
router = express.Router();

router.all("/", CNINFO.InfoControl);

module.exports = router;
FNPRINT.iPrint("Started Info Route")
