const fetch = (...args) => import("node-fetch").then(({default: fetch}) => fetch(...args));
const formData = require('form-data');
const fs = require('node:fs');
const CGWEB = require("../config/webhooks.json");
const osu = require("node-os-utils");
module.exports = {

    SendObfuscatedWebhook: async function(scriptid, watermark,userid,cmdout) {

        var cpu = ""
        await osu.cpu.usage().then(cpuPercentage => {
            cpu = cpuPercentage
        })
    
        var ram = {}
        await osu.mem.info().then(ramPercentage => {
            ram = ramPercentage
        })

        await fetch(CGWEB.SuccessWebhook, {
                method: 'post',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    "content": "<@217353461933670403>",
                    "embeds": [{
                        "title": `Script ID: ${scriptid} - WaterMark: ${watermark}`,
                        "description": `Script Owner Name: <@${userid}> - [**[${userid}]**](http://tools.essaprime.xyz/discord/${userid}) \nCMD Output : \`\`\`fix\n${cmdout}\n \`\`\` `,
                        "color": 9988095,
                        "fields": [{
                                "name": "CPU Usage",
                                "value": `${cpu}/100%`,
                                "inline": true
                            },
                            {
                                "name": "Ram Usage",
                                "value": `${ram.usedMemMb}/${ram.totalMemMb}MB (${ram.freeMemPercentage}/100%)`,
                                "inline": true
                            },
                        ],
                        "author": {
                            "name": "New Obfuscation | EssaFuscatorAPI V2",
                            "icon_url": "https://media.discordapp.net/attachments/889864564093632522/972441495820980244/EssaFuscatorClean.png?width=696&height=676"
                        },
                        "footer": {
                            "text": "EssaFuscator Obfuscation Report",
                            "icon_url": "https://media.discordapp.net/attachments/889864564093632522/972441495820980244/EssaFuscatorClean.png?width=696&height=676"
                        },
                        "timestamp": new Date().toISOString(),
                        "thumbnail": {
                            "url": "https://media.discordapp.net/attachments/889864564093632522/972441495820980244/EssaFuscatorClean.png?width=696&height=676"
                        }
                    }]
                }),
            }
        );
    },

    SendStatusMessage: async function(ip) {
        
        var cpu = ""
        await osu.cpu.usage().then(cpuPercentage => {
            cpu = cpuPercentage
        })
    
        var ram = {}
        await osu.mem.info().then(ramPercentage => {
            ram = ramPercentage
        })

        await fetch(CGWEB.StatusWebhook, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                "content": null,
                "embeds": [
                    {
                        "title": "System Operational",
                        "description": "**Debug Info:**\n===========================================",
                        "color": 2096896,
                        "fields": [
                            {
                                "name": "CPU Stats:",
                                "value": `${cpu}/100%`
                            },

                            {
                                "name": "Ram Stats:",
                                "value": `${ram.usedMemMb}/${ram.totalMemMb}MB (${ram.usedMemPercentage}/100%)`
                            },
                            {
                                "name": "Requested From:",
                                "value": `${ip}`
                            }
                        ],
                        "author": {
                            "name": "EssaFuscator System",
                            "url": "https://discord.gg/obfuscate",
                            "icon_url": "https://media.discordapp.net/attachments/889864564093632522/972441495502200832/EssaFuscatorBurn.png?width=696&height=676"
                        },
                        "footer": {
                            "text": "EssaFuscatorV2 | Status Report",
                            "icon_url": "https://media.discordapp.net/attachments/889864564093632522/972441495502200832/EssaFuscatorBurn.png?width=696&height=676"
                        },
                        "timestamp": new Date().toISOString(),
                        "thumbnail": {
                            "url": "https://media.discordapp.net/attachments/889864564093632522/972441495502200832/EssaFuscatorBurn.png?width=696&height=676"
                        }
                    }
                ]
            }),
        });
    },

    SendSystemStart: async function(clusterid) {
        
        var cpu = ""
        await osu.cpu.usage().then(cpuPercentage => {
            cpu = cpuPercentage
        })
    
        var ram = {}
        await osu.mem.info().then(ramPercentage => {
            ram = ramPercentage
        })

        await fetch(CGWEB.SystemStarts, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                "content": "@here | System Started",
                "embeds": [
                    {
                        "title": "The API Has Been Started",
                        "description": "**Debug Info:**\n===========================================",
                        "color": 16052215,
                        "fields": [
                            {
                                "name": "CPU Stats:",
                                "value": `${cpu}/100%`
                            },

                            {
                                "name": "Ram Stats:",
                                "value": `${ram.usedMemMb}/${ram.totalMemMb}MB (${ram.usedMemPercentage}/100%)`
                            },
                            {
                                "name": "Cluster ID:",
                                "value": `${clusterid}`
                            }
                        ],
                        "author": {
                            "name": "EssaFuscatorAPI V2",
                            "url": "https://discord.gg/obfuscate",
                            "icon_url": "https://media.discordapp.net/attachments/889864564093632522/972441495502200832/EssaFuscatorBurn.png?width=696&height=676"
                        },
                        "footer": {
                            "text": "EssaFuscatorV2 | Status Report",
                            "icon_url": "https://media.discordapp.net/attachments/889864564093632522/972441495502200832/EssaFuscatorBurn.png?width=696&height=676"
                        },
                        "timestamp": new Date().toISOString(),
                        "thumbnail": {
                            "url": "https://media.discordapp.net/attachments/889864564093632522/972441495502200832/EssaFuscatorBurn.png?width=696&height=676"
                        }
                    }
                ]
            }),
        });
    },
    SendSQLBackup: async function(filename,filepath,epoch1){

        const form = new formData();
        form.append(filename, fs.createReadStream(filepath)); 
        const newtime = Math.floor(new Date().getTime() / 1000)
        form.append("payload_json", JSON.stringify({
            "content": null,
            "embeds": [
              {
                "title": "EssaFuscator Auto MariaDB Backup",
                "url": "https://discord.gg/obfuscate",
                "color": 6248703,
                "fields": [
                  {
                    "name": "Backup Done At:",
                    "value": `<t:${newtime}:d> | <t:${newtime}:T> or <t:${newtime}:R>`,
                    "inline": true
                  },
                  {
                    "name": "Path On Server:",
                    "value": `\`${filepath}\``
                  },
                  {
                    "name": "Time It Took To Backup:",
                    "value": `\`${newtime - epoch1}\``
                  }
                ],
                "footer": {
                  "text": "System Coded By ! EssaPrime#0001",
                  "icon_url": "https://tools.essaprime.xyz/discordavatar/217353461933670403"
                },
              }
            ],
            "username": "EssaFuscator System",
            "avatar_url": "https://media.discordapp.net/attachments/961321046332563496/982925387174641684/EssaFuscatorClean.png?width=696&height=676",
          })); 
        await fetch(CGWEB.SQLBackup,{
            'method': 'POST',
            'body': form,
            headers: form.getHeaders()
        })
    }
}