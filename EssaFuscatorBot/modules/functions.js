const Colors = require('colors');
const { WebhookClient,MessageEmbed } = require('discord.js');

module.exports = {
    Print: (text) => {
        var newTime = new Date().toLocaleTimeString();

        console.log(`[${Colors.green(newTime)}] : ${text}`);
    },

    CreateEmbed: (title, description,color) => {
        let embed = new MessageEmbed();

        embed.setAuthor("EssaFuscator System V2", "https://cdn.discordapp.com/avatars/773427936031408139/c2d58619653c4d0e47882fc3b74a4139.png?size=128");

        if (title !== 'none') {
            embed.setTitle(title);
        };

        if (description !== 'none') {
            embed.setDescription(description);
        };
        
        if (color !== 'none') {
            embed.setColor(color);
        };

        embed.setTimestamp();
        embed.setFooter('Coded By EssaPrime, Bot Version: V2', "https://tools.essaprime.xyz/discordavatar/217353461933670403");

        return embed;
    },

    ErrorHandler: (ErrorTitle, ErrorDesc,MentionAll,FileName, wid, wtoken) => {
        const webhookClient = new WebhookClient({ id: wid, token: wtoken });
        const embed = new MessageEmbed()
        .setTitle(ErrorTitle)
        .setColor('#F30C0C')
        .setDescription(`** Error Description: ** \n \`\`\`fix\n${ErrorDesc}\n \`\`\` `)
        .addFields(
            {name:"Error Time: ", value:`> <t:${Math.floor(new Date().getTime() / 1000)}:d> | <t:${Math.floor(new Date().getTime() / 1000)}:T>`},
            {name:"Error File: ", value:`> ${FileName}`}
        )
        .setTimestamp()
        .setFooter({ text: 'Error Compressed', iconURL: 'https://cdn.discordapp.com/avatars/773427936031408139/26a8608f15b554789a2abaa92947d9cc.png?size=1024' });
    
            content = "X"
        if (!MentionAll) {
            content = "EssaPrime Security System"
        }else{
            content = "@everyone | @here > DANGEROUS ERROR"
        }
        webhookClient.send({
            content: content,
            username: 'EssaPrime Error Logger',
            avatarURL: 'https://media.discordapp.net/attachments/720494690121809923/968818526141960192/IMG-7116.JPG?width=676&height=676',
            embeds: [embed],
        });
        return embed
    }
};