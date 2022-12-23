const CNEPDATA = require('../controllers/epdatatable'); 
const FNPRINT = require("../functions/print")
const express = require("express")
router = express.Router();

router.get("/", CNEPDATA.EPSender);

module.exports = router;
FNPRINT.iPrint("Started DataTable Route")
