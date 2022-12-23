const CNOBF = require('../controllers/obfuscate'); 
const FNPRINT = require("../functions/print")
const express = require("express")
router = express.Router();

router.post("/:enctype?", CNOBF.OBFControl);

module.exports = router;
FNPRINT.iPrint("Started Obfuscation Route")
