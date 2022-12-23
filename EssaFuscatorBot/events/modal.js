const Functions = require('../modules/functions');
const Discord = require('discord.js');
const { REST } = require('@discordjs/rest');
const { Routes } = require('discord-api-types/v9');
const config = require("../config.json")
const rest = new REST({ version: '9' }).setToken(config.token);

const mdb = require('knex-mariadb');
const knex = require('knex')({
    client: mdb,
    connection: {
        host: '127.0.0.1',
        port: 3306,
        user: 'root',
        password: '4H9YNdAZkAwcekZVel505RAYasa6OcfHHCiX0YFBy3bqfqYY',
        database: 'scripts'
    }
});

module.exports = {
	name: 'modal',
	async execute(modal) {
        if(modal.customId === 'modal-scriptowner'){
            await modal.deferReply()
            const firstResponse = modal.fields[0].value
            knex.select().from('owners').where('script_id', firstResponse).then(async(data) => {
                if (Object.keys(data).length > 0) {
                    console.log(data)
                    var scriptdate;
                    if (data[0].date == "V2Obfuscation") {
                        scriptdate =`<t:${data[0].epoch}:d> | <t:${data[0].epoch}:T>`
                    }else{
                        scriptdate =  data[0].date
                    }
                    var userinfo = await rest.get(Routes.user(data[0].user_id))
                    var username = `${userinfo.username}#${userinfo.discriminator}`
                    var scriptowner = data[0].user_id
                    var scriptkey = data[0].script_id
                    
                    const sdsdsdembed = new Discord.MessageEmbed()
                    .setColor('#0099ff')
                    .setTitle('EssaFuscator Script Owner Finder!')
                    .setAuthor(`${modal.user.username}`, `${modal.user.displayAvatarURL()}`)
                    .setDescription('EssaFuscator Script Owner Finder!')
                    .addFields(
                        { name: 'Script Owner', value: `<@${scriptowner}>`, inline: true },
                        { name: 'Date Created', value: scriptdate, inline: true },
                        { name: 'Script Owner Username', value: `${username}`, inline: true },
                        { name: 'Script ID', value: scriptkey, inline: false },
                    );
                    modal.editReply({
                        embeds: [sdsdsdembed],
                    })
                }else{
                    modal.editReply({
                        embeds: [Functions.CreateEmbed('EssaFuscator Script Owner Finder', "> **Owner Not Found**\n> **The File Is Most Likely Old Or The ID Doesn't Exist!**", 'YELLOW')],
                    })
                }
            })
        }
    },
};