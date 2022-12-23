const CGEXPRESS = require("./v2/config/express.json")
const FNPRINT = require("./v2/functions/print")
const FNWEB = require("./v2/functions/webhooks")
const cluster = require('cluster');
const numCPUs = require('os').cpus().length;

if (cluster.isMaster) {
	require("./security/mariadblog.js");
    for (var i = 0; i < numCPUs; i++) {
        cluster.fork();
    }
	Object.keys(cluster.workers).forEach(async(id) => {
        await FNWEB.SendSystemStart(cluster.workers[id].process.pid)
        FNPRINT.sPrint("CLUSTER: ( " + cluster.workers[id].process.pid + " ) STARTED");
    });
	
    cluster.on('exit', function(worker, code, signal) {
        FNPRINT.ePrint('CLUSTER ( ' + worker.process.pid + ' ) DIED');
    });
} else {
    require("./index.js");
}

process.on('unhandledRejection', (reason, p) => {
    FNPRINT.ePrint(`unhandledRejection | ${reason} -x[] ${JSON.stringify(p)}`);
})

process.on('uncaughtException', err => {
    FNPRINT.ePrint(`uncaughtException | ${err}`);
});