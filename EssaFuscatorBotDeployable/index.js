// Deployable Version Of The EssaFuscator Bot | Written By ! EssaPrime#0001 -> Discord.js V12*
const Discord = require('discord.js');
const client = new Discord.Client();
const fs = require('node:fs');
const fetch = (...args) => import("node-fetch").then(({ default: fetch }) => fetch(...args));
const {EssaFuscator} = require('essafuscator')

/*
    طريقة الاستعمال:
    تكتب !obfuscate مع الملف المشفر
*/

const config = {
    bot: { // اعدادات البوت | Bot Settings
        bottoken: '', // توكن البوت | Bot Token
        prefix: '!', // برفكس البوت | Bot Prefix
        status: 'At discord.gg/obfuscate', // حالة البوت | Bot Status
    },
    team: {
        fileprefix: 'Obfuscated-' // برفكس الملفات | File Prefix
    },
    obfuscation: {
        apikey: '', // الكي حقك | API Key
        obfuscationskin: 'arabic', // شكل الملف المشفر | ByteCode Skin (arabic/emoji)
        watermark:'EssaFuscator On TOPPPPPPP' // الحقوق الي تطلع في الملف المشفر  | Watermark
    }
}

const EFOBF = new EssaFuscator(config["obfuscation"]["apikey"])


client.on('ready', () => {
    client.user.setActivity(config["bot"]["status"], {
        type: "PLAYING",
    })
    console.log(`[EssaPrime]: Logged in as ${client.user.tag}!`)
})

client.on('message', async message => {
    if (message.author.bot || !message.content.startsWith(config["bot"]["prefix"])) return;
    const args = message.content.slice(config["bot"]["prefix"].length).trim().split(/ +/);
    const command = args.shift().toLowerCase();
    if (command == "obfuscate") {
        message.channel.startTyping()
        if (message.attachments.size == 0) {message.channel.stopTyping();return message.reply("You have to upload a file")};
        const {url,name} = message.attachments.first();
        if (!name.endsWith('.lua')) {message.channel.stopTyping();return message.reply("The File Must End With .lua")};
        const key = new Date().getTime();
        const response = await fetch(url);
        const body = await response.text();
        var filename = `files/obfprime-${key}-${name}`;
        EFOBF.obfuscate(body,config['obfuscation']["watermark"],config["obfuscation"]["obfuscationskin"],async(obffile) => {
            await fs.writeFile(filename, `${obffile}`, function(err) {
                if (err) throw err;
                const attachment = new Discord.MessageAttachment(filename, `${config["team"]["fileprefix"]}${name}`);
                message.channel.send(attachment)
                message.channel.stopTyping()
            });      
        })    
    }
})

process.on('unhandledRejection', (reason, p) => {
    console.error(reason, 'Unhandled Rejection at Promise', p);
})

client.login(config['bot']['bottoken'])