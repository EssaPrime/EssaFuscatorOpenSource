const FNPRINT = require("../v2/functions/print");;
const FNWEBHOOKS = require("../v2/functions/webhooks")
const CNMARIA = require("../v2/config/mariadb.json");
const mysqldump = require('mysqldump');


(async function() {
    FNPRINT.sPrint('MariaDB Backup Started')
    const currtime = Math.floor(new Date().getTime() / 1000)
    const name = `./security/SQLBackups/EssaFuscatorSQLAuto-${currtime}.sql`
    const webhookname = `EFSQL-${currtime}.sql`
    await mysqldump({
        connection: {
            host: CNMARIA.host,
            user: CNMARIA.user,
            password: CNMARIA.password,
            database: CNMARIA.database,
        },
        dumpToFile: name,
    });
   
    await FNWEBHOOKS.SendSQLBackup(webhookname,name,currtime);

    FNPRINT.sPrint('MariaDB Backup Sent')
    setTimeout(arguments.callee, 32400000); // 9 Hours
})();
