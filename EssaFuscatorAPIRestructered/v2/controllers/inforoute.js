const FNPRINT = require("../functions/print")
const cluster = require('cluster');


const InfoControl = async(req, res, next) => {
    var currentcluster = ""
    if (cluster.isMaster) {
        currentcluster = "EF_MAIN"
      } else if (cluster.isWorker) {
        currentcluster = "EF_CLUSTER-" + cluster.worker.id;
      }

    res.status(200).end(JSON.stringify({
        version:"EF_2.7.A",
        apiversion:"EF_API_V2",
        discord:"https://discord.gg/obfuscate",
        developer:"! EssaPrime#0001",
        currentserver:currentcluster
    }));
};

module.exports = {InfoControl};
FNPRINT.iPrint("Started Info Controller")
