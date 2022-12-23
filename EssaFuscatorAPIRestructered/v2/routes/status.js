const CNSTATUS = require('../controllers/status'); 
const FNPRINT = require("../functions/print")
const express = require("express")
router = express.Router();

router.get("/", CNSTATUS.STATControl);

module.exports = router;
FNPRINT.iPrint("Started Status Route")