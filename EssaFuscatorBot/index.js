const Discord= require('discord.js');
const client = new Discord.Client({ intents: ["GUILDS", "GUILD_MESSAGES", "DIRECT_MESSAGES", "GUILD_MEMBERS", "GUILD_EMOJIS_AND_STICKERS", "GUILD_MESSAGE_REACTIONS", "GUILD_MESSAGE_TYPING"], partials: ['MESSAGE',"CHANNEL"] });


const discordjsModal = require('discordjs-modal');
discordjsModal(client); 

const Colors = require('colors');
const Functions = require('./modules/functions');
const fs = require("fs");
const { token,Client_ID , Guild_ID} = require('./config.json');

client.commands = new Discord.Collection()

/////////////////////////

const commandFolder = fs.readdirSync( './commands' ).filter( x => x.endsWith( '.js' ) )
for (const file of commandFolder) {
    const command = require(`./commands/${file}`);
    client.commands.set(command.data.name, command);
}

const eventFiles = fs.readdirSync('./events').filter(file => file.endsWith('.js'));

for (const file of eventFiles) {
	const event = require(`./events/${file}`);
	if (event.once) {
		client.once(event.name, (...args) => event.execute(...args));
	} else {
		client.on(event.name, (...args) => event.execute(...args));
	}
}

/////////////////////////

process.on('unhandledRejection', (reason, p) => {
    console.error(reason, 'Unhandled Rejection at Promise', p);
    Functions.ErrorHandler("unhandledRejection", `${reason} Unhandled Rejection At Promise ${p}`,false,__filename, "968824422590976041", "W5Bll36OrHqm7_JgC3rWKAOK2fMiyarc0c7TGUB7qrw-MYr1GgZXQXLaBoJfmvUiMk2n")
})
process.on('uncaughtException', err => {
    console.error(err, 'Uncaught Exception thrown');
    Functions.ErrorHandler("uncaughtException", `${err} Uncaught Exception thrown`,true,__filename, "968824614098722856", "D2lA0bRcL_jaV6BUjqat4dJlknWzpg7S4yn6cF_haDrvPl1dh3S94Ss9ym23Eo2SPyqE")

});

client.login(token).catch((error) => {
    console.log(`[${Colors.red('Discord')}] Unable to connect with <${Colors.red('Discord')}>`);
    console.log(`[${Colors.red('Discord')}] ${error.message ? error.message : error}`);
    Functions.ErrorHandler("Login Error", `${error.message ? error.message : error}`,true,__filename, "968824792855769128", "pFt8LG0Bz3NTkg526IKqQwd_1f98giSKsM-dC_t6Ht8k3pUgzQzKlqCRvpLusi_jNZP1")

});    
