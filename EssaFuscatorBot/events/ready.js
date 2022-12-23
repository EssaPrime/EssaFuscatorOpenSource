const { REST } = require('@discordjs/rest');
const { Routes } = require('discord-api-types/v9');
const Functions = require('../modules/functions');
const fs = require("fs");
const { token,Client_ID , Guild_ID} = require('../config.json');
const Colors = require('colors');

module.exports = {
	name: 'ready',
	once: false,
	async execute(client) {
		Functions.Print(`[${Colors.green('Discord')}] Hello World! I'm logged in as ${Colors.green(client.user.tag)}`);
        client.user.setActivity("EssaFuscator | /help" ,{type:"COMPETING",})
        const commands = [];
        const commandFiles = fs.readdirSync('./commands/').filter(file => file.endsWith('.js'));
        const clientId = Client_ID;
        const rest = new REST({ version: '9' }).setToken(token);
        for (const file of commandFiles) {
            const command = require(`../commands/${file}`);
            commands.push(command.data.toJSON());
        }
        (async () => {
            try {
                await rest.put(Routes.applicationCommands(clientId),
                { body: commands },
                );
            } catch(error) {
                Functions.ErrorHandler("Rest Command PUT Error", `${error}`,true,__filename, "968825152672509952", "5Elfm3ODJxCHDpBn3Cryk4TLG8IeV6c6JDvrSjU3sCIw-qQOcedHampJ71yGX7x4h_lH")
                console.log(error);
            }
        })();
	},
};