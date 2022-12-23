const CGMARIA = require("../config/mariadb.json")
const mdb = require('knex-mariadb');
const fs = require("fs");
const knex = require('knex')({
    client: mdb,
    connection: {
        host: CGMARIA.host,
        port: CGMARIA.port,
        user: CGMARIA.user,
        password: CGMARIA.password,
        database: CGMARIA.database
    }
});
module.exports = {

    InsertNewScript: async function(scriptid, userid, error) {
        await knex('owners').insert({
            script_id: scriptid,
            user_id: userid,
            date: "V2Obfuscation",
            epoch: Math.floor(new Date().getTime() / 1000)
        })
        .then(async (created) => {
            if (!created) {
                error("SQL Insert Error")
            }else{
                error(null)
            }
        });
    },

    CheckAPIKey: async function(apikey, valid) {
        await knex.select().from('keys').where('sha512', apikey).then(async (data) => {
            if (Object.keys(data).length > 0) {
                valid(data[0].user_id)
            }else{
                valid(false)
            }
        });
    },

    GetObfuscationCount: async function(cb) {
        await knex('owners').count('user_id').then((res)=>{
            cb(res[0]["count(`user_id`)"])
        })
    },

    ValidateDownload: async function(userid,userhash,filename,status) {
        await knex.select().from('downloadlinks').where('userid', userid).where('userhash', userhash).where('realname', filename).then(async (data) => {
            if (Object.keys(data).length > 0) {
                await knex("downloadlinks").where('userid', userid).where('userhash', userhash).where('realname', filename).update({timesopened: data[0].timesopened + 1})
                if (data[0].timesopened <= 4) {
                    status("GOOD");
                }else{
                    status("EXPIRED");
                } 
            }else{
                status("UNKNOWN")
            }
        });
    },

    AddToCDN: async function(code,userid,userhash,success) {
        var filehashe = (Math.random() + 1).toString(36).substring(7);
        const fullname = `${userhash}-${filehashe}.lua`
        await fs.writeFileSync(`./Obfuscator/CDN/${fullname}`, code)
        await knex('downloadlinks').insert({
            userid: userid,
            userhash: userhash,
            realname: `${filehashe}.lua`,
            epoch: Math.floor(new Date().getTime() / 1000),
            timesopened: 0,
        }).then(async (created) => {
            if (created) {
                success({url:`https://api.essafuscator.net/cdn/${userid}/${userhash}/${filehashe}.lua?json=true`})
            }else{
                success({error: "SQL Insert Error At CDN"})
            }
        });
    }
}