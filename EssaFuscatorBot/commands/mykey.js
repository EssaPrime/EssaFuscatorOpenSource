const { SlashCommandBuilder } = require('@discordjs/builders');
const Discord = require('discord.js');

const mdb = require('knex-mariadb');
const Functions = require('../modules/functions');
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
		.setName('mykey')
		.setDescription('To Get Your API Key | لمعرفة رمز الاي بي اي الخاص بك'),
	async execute(interaction) {
		await interaction.deferReply();
		knex.select()
		.from("keys")
		.where("user_id", interaction.user.id)
		.then(userNametList => {
			if (userNametList.length === 0) {
				interaction.editReply({
					embeds: [Functions.CreateEmbed('EssaFuscator API Key', ">  **You Don't Have A API Key**\n**Generate One Using The `!essafus` Command Menu!**", 'RED')],
					ephemeral: true
				})
			}else{
				knex.select().from('keys').where('user_id', interaction.user.id).then(async(data) => {
					if (Object.keys(data).length > 0) {
						console.log(data)
						var apikeyy = data[0].sha512
						var owner = data[0].user_id
						var dateandtuime = data[0].datecreated
						const sdsdsdembed = new Discord.MessageEmbed()
						.setColor('#0099ff')
						.setTitle('EssaFuscator Menu!')
						.setAuthor(`${interaction.user.username}#${interaction.user.discriminator}`, `${interaction.user.displayAvatarURL()}`)
						.setDescription('EssaFuscator API Key Info!')
						.addFields(
							{ name: 'Key Owner', value: `<@${owner}>`, inline: true },
							{ name: 'Date Created', value: dateandtuime, inline: true },
							{ name: 'API KEY', value: '||'+ apikeyy+'|| ', inline: false },
						);
						if (interaction.channel.type == "DM") {
							interaction.editReply({embeds: [sdsdsdembed]})
						}else{
							interaction.user.send({embeds: [sdsdsdembed]})
							interaction.editReply({content: "Look At Your DM's | شوف الخاص", ephemeral: true})
						}
					}
				});
			}
			return;
		});
	},
};