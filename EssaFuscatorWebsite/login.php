<?php

require __DIR__ . "/phpfunc/discord.php";
require __DIR__ . "/phpfunc/functions.php";
require "./phpfunc/config.php";

init($redirect_url, $client_id, $secret_id, $bot_token);
get_user();
join_guild('773967604205223946');
redirect("../index.php");
