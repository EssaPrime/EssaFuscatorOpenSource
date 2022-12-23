const CNDOWNLOAD = require('../controllers/download'); 
const FNPRINT = require("../functions/print")
const express = require("express")
router = express.Router();

router.get("/:userid?/:userhash?/:realname?", CNDOWNLOAD.GetFile);

module.exports = router;
FNPRINT.iPrint("Started Download Route")
