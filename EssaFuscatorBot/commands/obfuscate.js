const { SlashCommandBuilder } = require('@discordjs/builders');
const fetch = (...args) => import("node-fetch").then(({default: fetch}) => fetch(...args));
const Functions = require('../modules/functions');
const fs = require("fs");
const {MessageActionRow,MessageButton} = require("discord.js");
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
	data: new SlashCommandBuilder()
    .setName('obfuscate')
    .setDescription('To Obfuscate A Script | لتشفير ملف')
    .addStringOption(option =>
        option.setName('watermark')
        .setDescription('The Script\'s Custom WaterMark | حقوقك الي بتنكتب على السكربت')
        .setRequired(true))
    .addBooleanOption(option =>
        option.setName('emojiskin')
        .setDescription('Emoji Skin | شكل البايتات [if true it\'ll use emojis as the skin]')
        .setRequired(true)),
    async execute(interaction,client) {
        await interaction.deferReply()
        var filter2 = m => (m.author.id == interaction.user.id);

        var reply = await interaction.editReply({
            embeds: [Functions.CreateEmbed('Send The File!', '> الرجاء رفع الملف\n> Please Upload The File', "RANDOM")],
            ephemeral: true
        });
        
        interaction.channel.awaitMessages({ filter2, max: 1, time: 30000 }).then(async (CollectedMessage) => {
            var msgs = CollectedMessage.first();
			if (!msgs | msgs == null | isNaN(msgs)) return interaction.editReply({content:"Error", embeds:[Functions.CreateEmbed('ERROR!', '> تأخرت, جرب مره ثانية\n> You Took Too Long, Try Again', "RED")]})
			if (msgs.attachments.size == 0) return interaction.editReply({content:"Error", embeds:[Functions.CreateEmbed('ERROR!', '> لازم ترفع ملف\n> You Have To Upload A File', "RED")]})
				
			interaction.editReply({content:"Preparing...", embeds:[Functions.CreateEmbed('Preparing To Obfuscate <a:loading2:983701058650013726>', '> سوف يتم التشفير بعد ثواني\n> Preparing To Obfuscate... Please Wait', "RANDOM")]})

            if (msgs.deletable && interaction.channel.type != "DM") await msgs.delete();
            var watermark = ""
            var encodetype = ""
            if (interaction.options.getString('watermark')) {watermark = interaction.options.getString('watermark')}else{watermark="discord.gg/obfuscate"}
            
            if (interaction.options.getBoolean('emojiskin')) {
				encodetype = "emoji"
			}else{
				encodetype = "arabic"
            }

            const {url,name} = msgs.attachments.first();
            await fetch(url).then(response => response.text()).then(async(text) => {
				interaction.editReply({content:"Obfuscating...", embeds:[Functions.CreateEmbed('Obfuscating <a:loading2:983701058650013726>', '> جاري التشفير\n> Obfuscating... Please Wait', "RANDOM")]})
                await fetch(`http://localhost:80/v2/obfuscate/${encodetype}/`, {
                    method: "post",
                    headers: {
                        "Content-Type": "application/json",
                        "EssaFuscatorAPIKey": "ESSA-" + msgs.author.id
                    },
                    body: JSON.stringify({
                        script: `${text}`,
                        watermark: watermark
                    })
                })
                .then(res => {
                    return res.text()
                })
                .then(async(text) => {
                    var response = await JSON.parse(text)
                    if (response.error) return interaction.editReply({content: "Error" ,embeds: [Functions.CreateEmbed('ERROR!', `>  الملف فيه ايرور او مب lua\n \`\`\`fix\n ${response.error} \n\`\`\` `, "RED")],ephemeral: false})
                    if (Buffer.byteLength(response.obfscript, 'utf8') > 1500000) {
                        knex('owners').count('user_id').then((res)=>{
                            interaction.client.user.setActivity(" [ "+res[0]["count(`user_id`)"]+" ] Obfuscations | /help" ,{type:"WATCHING"})
                        })
                        .catch((err)=>{
                            Functions.ErrorHandler("Knex Status Count Error", `${err}`,true,__filename, "968826017630265344", "2dRIXTbbkKv2BdHBsLCaAgN4MbjLW0dM_jxoZlLlES-_yJJSi3LmoJfmd0Dlxa37iSIr");
                            console.log("err "+err)
                        })
                        const linkbutton = new MessageActionRow()
                        .addComponents(
                        new MessageButton()
                            .setLabel('Click To Download')
                            .setURL((response.cdnlink).replace("?json=true","?json=false"))
                            .setStyle('LINK'),
                        );
                        return interaction.editReply({
                            components:[linkbutton],
                            embeds:[Functions.CreateEmbed('Success!', '> The File Was Obfuscated Successfully\n Click The Button Because The File Is Over 1.5MB', "PURPLE")],
                            content: "**Obfuscated!**",
                        });
                        
                    }

                    var directory = `C:/Users/Administrator/Desktop/EssaFuscatorRestructered/files/${msgs.author.id}`;
                    const key = new Date().getTime();
                    var filename = `EFuscated-${key}-${name}`;
                    if (!fs.existsSync(directory)){
                        fs.mkdirSync(directory);
                    }
                    console.log("REACHEDFILECREATION")
                    await fs.writeFile(`${directory}/${filename}`, `${response.obfscript}`, async(err) =>{
                        if (err) {Functions.ErrorHandler("User Folder Error", `${err}`,false,__filename, "968825524493381642", "IH8_KxDkJs6fYikceF0tw0JUBY6XLy33tLhEBMHGbBxuvM9cKXezwDpJ80qiFhoQSWHF")};
                        console.log("REACHED FILE SEND")
                        interaction.editReply({
                            files: [{
                                attachment: `${directory}/${filename}`,
                                name: `EssaFuscator-${name}.lua`
                            }],
                            embeds:[Functions.CreateEmbed('Success!', '> The File Was Obfuscated Successfully', "PURPLE")],
                            content: "**Obfuscated!**",
                        });
                        knex('owners').count('user_id').then((res)=>{
                            interaction.client.user.setActivity(" [ "+res[0]["count(`user_id`)"]+" ] Obfuscations | /help" ,{type:"WATCHING"})
                        })
                        .catch((err)=>{
                            Functions.ErrorHandler("Knex Status Count Error", `${err}`,true,__filename, "968826017630265344", "2dRIXTbbkKv2BdHBsLCaAgN4MbjLW0dM_jxoZlLlES-_yJJSi3LmoJfmd0Dlxa37iSIr");
                            console.log("err "+err)
                        })
                    })
                })
            })
        });
    },
};