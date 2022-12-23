const{ SlashCommandBuilder } = require('@discordjs/builders');
const discordjsModal = require('discordjs-modal');


module.exports = {
	data: new SlashCommandBuilder()
		.setName('scriptfinder')
		.setDescription('To Find The Script Owner | لمعرفة صاحب ملف مشفر'),
	async execute(interaction) {
        //await interaction.deferReply();
        const modal = new discordjsModal.Modal()
        .setCustomId("modal-scriptowner")
        .setTitle("بحث صاحب السكربت \n Script Owner Finder!")
        .addComponents(
            new discordjsModal.TextInput()
            .setLabel("الايدي | Script ID")
            .setStyle("SHORT")
            .setPlaceholder("اكتب الايدي هنا | Type The Script ID Here")
            .setCustomId("kalam-inputmodal")
            .setMinLength(14)
            .setMaxLength(22)
            .setRequired(true)
        )                        
        interaction.client.modal.send(interaction, modal)
    },
};