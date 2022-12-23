const Discord = require('discord.js');
const client = new Discord.Client({intents: ['GUILDS', 'GUILD_MEMBERS', 'GUILD_WEBHOOKS']});
const Canvas = require('canvas');
const fetch = (...args) => import("node-fetch").then(({default: fetch}) => fetch(...args));
Canvas.registerFont('Akira_Expanded.otf', { family: 'Akira Expanded' })
const fs = require('fs')

const messageid = ""

client.on("ready", async() => {

    console.log("Logged In As " + client.user.tag)

    setInterval(async function(){ 
        console.log("Iniatializing...")
        const canvas = Canvas.createCanvas(1920, 1080);
        const ctx = canvas.getContext('2d');
        const background = await  Canvas.loadImage('./status.png');
        ctx.drawImage(background, 0, 0, canvas.width, canvas.height);
        ctx.strokeStyle = '#f2f2f2';
        ctx.strokeRect(0, 0, canvas.width, canvas.height);
        var beforetime = Date.now()
        await fetch(`https://updown.io/api/checks/sxbo?api-key=FUbxofPiP3pPawBTmAb2`, {
            method: "get",
        }).then(res => {
            return res.json()
        }).then(async (response) => {
            if (response.down == true) {
                var SystemStatus = `Offline`;
                ctx.font = '55px Akira Expanded';
                ctx.shadowColor = "red"
                ctx.shadowBlur = 40
                ctx.fillStyle = '#E24949';
                await ctx.fillText(SystemStatus,560, canvas.height / 2 -255);

                var ObfuscationCount = `N/A`;
                ctx.font = '55px Akira Expanded';
                ctx.shadowColor = "red"
                ctx.shadowBlur = 40
                ctx.fillStyle = '#E24949';
                await ctx.fillText(ObfuscationCount,720, canvas.height / 2 -145);
                
                var DiscordPing = `N/A`;
                ctx.font = '55px Akira Expanded';
                ctx.shadowColor = "red"
                ctx.shadowBlur = 40
                ctx.fillStyle = '#E24949';
                await ctx.fillText(DiscordPing,680, canvas.height / 2 -35);
                
                var SystemPing = `N/A`;
                ctx.font = '55px Akira Expanded';
                ctx.shadowColor = "red"
                ctx.shadowBlur = 40
                ctx.fillStyle = '#E24949';
                await ctx.fillText(SystemPing,660, canvas.height / 2 +75);
                
                var DataBasePing = `N/A`;
                ctx.font = '55px Akira Expanded';
                ctx.shadowColor = "red"
                ctx.shadowBlur = 40
                ctx.fillStyle = '#E24949';
                await ctx.fillText(DataBasePing,730, canvas.height / 2 +185);
    
                var GuildMembers = `1068`;
                ctx.font = '55px Akira Expanded';
                ctx.shadowColor = "white"
                ctx.shadowBlur = 40
                ctx.fillStyle = '#F8FFF9';
                await ctx.fillText(GuildMembers,790, canvas.height / 2 +295);
                const attachment = new Discord.MessageAttachment(canvas.toBuffer(), 'essafuscatorstatus.png');
                let embed = new Discord.MessageEmbed()
                .setAuthor("System Is Offline", "https://media.discordapp.net/attachments/961321046332563496/972609594180390912/EssaRed.png?width=676&height=676")
                .setTitle('Click Me For More Info')
                .setURL('https://status.essafuscator.net/')
                .setColor('PURPLE')
                .setImage(`attachment://essafuscatorstatus.png`)
                .setTimestamp()
                .setFooter('Coded By EssaPrime', "https://cdn.discordapp.com/avatars/217353461933670403/73042522069f0fc66f36c5c51f3f17f5.png?size=1024");
                client.channels.cache.get('940223428219244584').messages.fetch(`972611191950172210`).then(msg =>{
                    msg.edit({
                        content: `**EssaFuscator System Status | This Embed Gets Updated Every 30 Seconds | ||@everyone||**`,
                        files: [attachment],
                        embeds : [embed]
                    });
                })
                console.log("Sent Offline...")
            }else{
                var aftertime =  Math.floor( ( Date.now()  - beforetime) / 10 )
                await fetch("https://api.essafuscator.net/v2/epdatatable", {
                    method: "get",
                }).then(res => {
                    return res.json()
                }).then(async (response) => {
                    console.log(response)
                    var SystemStatus = `Online`;
                    ctx.font = '55px Akira Expanded';
                    ctx.shadowColor = "green"
                    ctx.shadowBlur = 40
                    ctx.fillStyle = '#38DF40';
                    await ctx.fillText(SystemStatus,560, canvas.height / 2 -255);
    
                    var ObfuscationCount = `${response.obfuscations}`;
                    ctx.font = '55px Akira Expanded';
                    ctx.shadowColor = "white"
                    ctx.shadowBlur = 40
                    ctx.fillStyle = '#F8FFF9';
                    await ctx.fillText(ObfuscationCount,720, canvas.height / 2 -145);
                    
                    var DiscordPing = `${Math.round(client.ws.ping)}ms`;
                    ctx.font = '55px Akira Expanded';
                    ctx.shadowColor = "white"
                    ctx.shadowBlur = 40
                    ctx.fillStyle = '#F8FFF9';
                    await ctx.fillText(DiscordPing,680, canvas.height / 2 -35);
                    
                    var SystemPing = `${aftertime}ms`;
                    ctx.font = '55px Akira Expanded';
                    ctx.shadowColor = "white"
                    ctx.shadowBlur = 40
                    ctx.fillStyle = '#F8FFF9';
                    await ctx.fillText(SystemPing,660, canvas.height / 2 +75);
                    
                    var DataBasePing = `${response.databaseping}`;
                    ctx.font = '55px Akira Expanded';
                    ctx.shadowColor = "white"
                    ctx.shadowBlur = 40
                    ctx.fillStyle = '#F8FFF9';
                    await ctx.fillText(DataBasePing,730, canvas.height / 2 +185);

                    const guild = client.guilds.cache.get("773967604205223946");
                    var memberCount = guild.memberCount;  

                    var GuildMembers = `${memberCount}`;
                    ctx.font = '55px Akira Expanded';
                    ctx.shadowColor = "white"
                    ctx.shadowBlur = 40
                    ctx.fillStyle = '#F8FFF9';
                    await ctx.fillText(GuildMembers,790, canvas.height / 2 +295);

                    const attachment = new Discord.MessageAttachment(canvas.toBuffer(), 'essafuscatorstatus.png');
                    let embed = new Discord.MessageEmbed()
                    .setAuthor("System Is Online ", "https://media.discordapp.net/attachments/961321046332563496/972609593983238224/EssaGreen.png?width=646&height=676")
                    .setTitle('Click Me For More Info')
                    .setURL('https://status.essafuscator.net/')
                    .setColor('PURPLE')
                    .setImage(`attachment://essafuscatorstatus.png`)
                    .setTimestamp()
                    .setFooter('Coded By EssaPrime', "https://cdn.discordapp.com/avatars/217353461933670403/73042522069f0fc66f36c5c51f3f17f5.png?size=1024");
                    client.channels.cache.get('940223428219244584').messages.fetch(`972611191950172210`).then(msg =>{
                        msg.edit({
                            content: `**EssaFuscator System Status | This Embed Gets Updated Every 30 Seconds | ||@everyone||**`,
                            files: [attachment],
                            embeds : [embed]
                        });
                    })
                    
                    console.log("Sent Online...")

                })
            } 
        })
        }, 30000);
})

client.login("")
