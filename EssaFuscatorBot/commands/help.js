const { SlashCommandBuilder } = require('@discordjs/builders');
const Discord = require("discord.js")
module.exports = {
	data: new SlashCommandBuilder()
		.setName('help')
		.setDescription('To View The Help Commands | اوامر المساعدة'),
	async execute(interaction) {
        const embed = new Discord.MessageEmbed()
        .setColor('PURPLE')
		.setTitle('EssaFuscatorBot V2 | Help Panel')
		.setURL('https://discord.gg/obfuscate')
		.setDescription('Listed Below Are All The Help Commands\nفي الاسفل جميع اوامر البوت')
		.addFields(
			{ name: '> Obfuscate', value: '`/obfuscate`: To Obfuscate A Script | لتشفير سكربت' },
			{ name: '> Create A Key', value: '`/createkey`: To Create An API Key | لصنع رمز اي بي اي (API Key)' },
			{ name: '> Find Your Key', value: '`/mykey`: To Find Your API Key | لمعرفة الكي الخاص بك' },
			{ name: '> Find A Script Owner', value: '`/scriptfinder`: To Search For A Script\'s ID | لمعرفة صاحب الملف عن طريق الايدي الخاص بلملف المشفر'},
		)
		.setTimestamp()
		.setFooter({ text: 'EssaFuscatorBot V2 | Coded By ! EssaPrime#0001 >> EssaFuscator', iconURL: 'https://cdn.discordapp.com/avatars/773427936031408139/26a8608f15b554789a2abaa92947d9cc.png?size=1024' });
		await interaction.reply({content:"Help Message Below", embeds:[embed]});
	},
};