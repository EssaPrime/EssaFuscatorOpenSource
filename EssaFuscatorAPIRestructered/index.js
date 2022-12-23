const express = require('express')
const rateLimit = require('express-rate-limit')
const app = express()
const CGEXPRESS = require("./v2/config/express.json")
const FNPRINT = require("./v2/functions/print")
const fs = require("fs")
const limiter = rateLimit({
    skip: (request, response) => CGEXPRESS.RateLimitWhitelist.includes(CGEXPRESS.RateLimitWhitelist),
    windowMs: 5 * 60 * CGEXPRESS.RateLimitMS,
    max: 15,
    message: '{"error":"Too Many Requests Sent To This IP, Please Try Again In 1 Minute"}',
    standardHeaders: true,
    legacyHeaders: false,
})

var morgan = require('morgan')
var accessLogStream = fs.createWriteStream("./security/Logs/connections.log", { flags: 'a' })


app.use(morgan('\n\n------------------\nAt (:date[iso])\nIP (:req[cf-connecting-ip])\nMethod (:method)\nStatus (:status)\nPing (:response-time[3]/:total-time[3])\nURL https://essafuscator.net:url \n', { stream: accessLogStream }))
app.use(limiter)
app.use(express.json({ limit: CGEXPRESS.Filelimit }));

var obfuscationroute = require("./v2/routes/obfuscate");
var statusroute = require("./v2/routes/status");
var datatableroute = require("./v2/routes/epdatatable")
var downloadroute = require("./v2/routes/download")
var inforoute = require("./v2/routes/inforoute")
app.use("/v2/obfuscate", obfuscationroute)
app.use("/v2/status", statusroute)
app.use("/v2/epdatatable", datatableroute)
app.use("/cdn", downloadroute)
app.use("/v2", inforoute)
app.use("/", inforoute)

app.listen(CGEXPRESS.Port, async () => {
    FNPRINT.iPrint(`Started On Port ${CGEXPRESS.Port}`)
})

process.on('unhandledRejection', (reason, p) => {
    FNPRINT.ePrint(`unhandledRejection | ${reason} -x[] ${JSON.stringify(p)}`);
})

process.on('uncaughtException', err => {
    FNPRINT.ePrint(`uncaughtException | ${err}`);
});