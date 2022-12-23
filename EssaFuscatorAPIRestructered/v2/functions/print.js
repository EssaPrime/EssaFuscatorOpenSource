const color = require("colors");


module.exports = {
    sPrint: function(message) {
        return console.log(color.green(`> [Obfuscation Success] - {${formatDate(new Date())}} =>> `, color.brightGreen(`[${message}]\n`)))
    },
    ePrint: function(message) {
        return console.log(color.red(`> [Error] - {${formatDate(new Date())}} =>> `, color.brightRed(`[${message}]\n`)))
    },
    iPrint: function(message) {
        return console.log(color.green(`> [System] - {${formatDate(new Date())}} =>> `, color.brightMagenta(`[${message}]\n`)))
    },
}

function padTo2Digits(num) {
    return num.toString().padStart(2, '0');
}
  
function formatDate(date) {
    return (
        [
            date.getFullYear(),
            padTo2Digits(date.getMonth() + 1),
            padTo2Digits(date.getDate()),
        ].join('-') +
        ' ' +
        [
            padTo2Digits(date.getHours()),
            padTo2Digits(date.getMinutes()),
            padTo2Digits(date.getSeconds()),
        ].join(':')
    );
}
