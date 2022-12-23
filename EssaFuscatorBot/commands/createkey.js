const { SlashCommandBuilder } = require('@discordjs/builders');
const {MessageAttachment} = require("discord.js")
const md5 = require('md5');
const mdb = require('knex-mariadb');
const Functions = require('../modules/functions');
const Captcha = require("@haileybot/captcha-generator");
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
    .setName('createkey')
    .setDescription('Create\'s an API Key | لصنع رمز اي بي اي'),
	async execute(interaction) {
        await interaction.deferReply();
        knex.select()
        .from("keys")
        .where("user_id", interaction.user.id)
        .then(userNametList => {
            var apikey = md5(interaction.user.id + Date.now())
            if (userNametList.length === 0) {
                console.log("Not Found")

                let captcha = new Captcha();
                const attachment = new MessageAttachment(captcha.JPEGStream, 'EssaPrimeIsDaddy.jpeg');
                const filter = response => {
                    return (interaction.user.id == response.author.id);
                };
                
                interaction.editReply({
                    embeds: [Functions.CreateEmbed("Captcha System",`> Please Fill The Captcha\n> الرجاء كتابة الكلام الي داخل الصورة`,"RANDOM").setImage(`attachment://EssaPrimeIsDaddy.jpeg`)],
                    files: [attachment]
                });
                interaction.channel.awaitMessages({ filter, max: 1, time: 20000}).then(async(collected) => {
					var messagecheck = collected.first();
					if (!messagecheck | messagecheck == null | isNaN(messagecheck)) return interaction.editReply({embeds: [Functions.CreateEmbed("Captcha System",`> You Took Too Long!\n> اخذت وقت كثير`,"RED")], files: []}); 
					if (messagecheck.content.toLowerCase() != captcha.value.toLowerCase()) return interaction.editReply({embeds: [Functions.CreateEmbed("Captcha System",`> You Failed!\n> فشلت. الرجاء المحاولة مره ثانية`,"RED")], files: []});
                    interaction.editReply(Functions.CreateEmbed("Captcha System",`> Success, Creating API Key Now!\n> نجحت. جاري صنع الكي الخاص بك`,"GREEN"));
                    var d = new Date();
                    var datestring = d.getDate()  + "-" + (d.getMonth()+1) + "-" + d.getFullYear() + " " + d.getHours() + ":" + d.getMinutes();
                    knex('keys').insert({ sha512: apikey, user_id: interaction.user.id, datecreated: datestring })
                    .then((created) => {
                        console.log('inserted user', created);
                        if (interaction.channel.type == "DM") {
                            interaction.editReply({
                                embeds: [Functions.CreateEmbed('> EssaFuscator API Key', "> ||" + apikey + "||", 'RANDOM')],
								files: [],
                                ephemeral: true
                            })
                        }else{
                            interaction.user.send({
                                embeds: [Functions.CreateEmbed('EssaFuscator API Key', "> ||" + apikey + "||", 'RANDOM')],
                                ephemeral: true
                            })
                            interaction.editReply({embeds:[Functions.CreateEmbed("Captcha System",`> Success, The API Key Was Sent To Your DM's!\n> نجحت. تم ارسال الكي الخاص بك في الخاص`,"GREEN")],content: `<@${interaction.user.id}>`,files:[], ephemeral: true})
                        }
                    });
                })
                .catch(collected => {
                });                  
            }else{
                knex.select("sha512").from('keys').where('user_id', interaction.user.id).then(async(data) => {
                    if (Object.keys(data).length > 0) {
                        var alreadykey = data[0].sha512
                        console.log("RANN")
                        if (interaction.channel.type == "DM") {
                            interaction.editReply({
                                embeds: [Functions.CreateEmbed('EssaFuscator API Key', '> You Already Have A API Key!\n' + "||" + alreadykey + "||", 'YELLOW')],
                                ephemeral: true
                            })
                        }else{
                            interaction.user.send({
                                embeds: [Functions.CreateEmbed('EssaFuscator API Key', '> You Already Have A API Key!\n' + "||" + alreadykey + "||", 'YELLOW')],
                                ephemeral: true
                            })
                            interaction.editReply({content: "Look At Your DM's | شوف الخاص", ephemeral: true})
                        }                                            
                    }
                });
            }
            return;
        });
	},
};