<?php
session_start();
$GLOBALS['base_url'] = "https://discord.com";
$GLOBALS['bot_token'] = "";
function gen_state()
{
    $_SESSION['state'] = bin2hex(openssl_random_pseudo_bytes(12));
    return $_SESSION['state'];
}

function SendDM($endpoint, $data) {
    $url = "https://discord.com/api/".$endpoint."";
    $data = json_encode($data);
    $ch = curl_init();
    curl_setopt_array($ch, array(
        CURLOPT_URL            => $url, 
        CURLOPT_HTTPHEADER     => array(
            'Authorization: Bot '.$GLOBALS['bot_token'],
            "Content-Type: application/json",
            "Accept: application/json"
        ),
        CURLOPT_RETURNTRANSFER => 1,
        CURLOPT_FOLLOWLOCATION => 1,
        CURLOPT_VERBOSE        => 1,
        CURLOPT_SSL_VERIFYPEER => 0,
        CURLOPT_POSTFIELDS => $data,
    ));
    $request = curl_exec($ch);
    curl_close($ch);
    return json_decode($request, true);
}

function init($redirect_url, $client_id, $client_secret, $bot_token = null)
{
    if ($bot_token != null)
        $GLOBALS['bot_token'] = $bot_token;
    $code = $_GET['code'];
    $state = $_GET['state'];
    $url = $GLOBALS['base_url'] . "/api/oauth2/token";
    $data = array(
        "client_id" => $client_id,
        "client_secret" => $client_secret,
        "grant_type" => "authorization_code",
        "code" => $code,
        "redirect_uri" => $redirect_url
    );
    $curl = curl_init();
    curl_setopt($curl, CURLOPT_URL, $url);
    curl_setopt($curl, CURLOPT_POST, true);
    curl_setopt($curl, CURLOPT_POSTFIELDS, http_build_query($data));
    curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
    $response = curl_exec($curl);
    curl_close($curl);
    $results = json_decode($response, true);
    $_SESSION['access_token'] = $results['access_token'];
}

function get_user()
{
    $url = $GLOBALS['base_url'] . "/api/users/@me";
    $headers = array('Content-Type: application/x-www-form-urlencoded', 'Authorization: Bearer ' . $_SESSION['access_token']);
    $curl = curl_init();
    curl_setopt($curl, CURLOPT_URL, $url);
    curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
    curl_setopt($curl, CURLOPT_HTTPHEADER, $headers);
    $response = curl_exec($curl);
    curl_close($curl);
    $results = json_decode($response, true);
    $_SESSION['user'] = $results;
    $_SESSION['username'] = $results['username'];
    $_SESSION['discrim'] = $results['discriminator'];
    $_SESSION['user_id'] = $results['id'];
    $_SESSION['user_avatar'] = $results['avatar'];


    $extention = is_animated($_SESSION['user_avatar']);

    $headers = [ 'Content-Type: application/json; charset=utf-8' ];
    $POST = [ 
        'username' => 'EssaFuscator Website Login',
        "embeds" => [
            [
                "title" => "A User Logged In",
                "type" => "rich",
                "timestamp" => date("c", strtotime("now")),
                "thumbnail" => [
                    "url" => "https://cdn.discordapp.com/avatars/".$_SESSION['user_id']."/".$_SESSION['user_avatar'].$extention
                ],
                "color" => "8086240",
                "footer" => [
                    "text" => "essafuscator.net",
                    "icon_url" => "https://cdn.discordapp.com/avatars/217353461933670403/73042522069f0fc66f36c5c51f3f17f5.webp?size=1024"
                ],
                
                "fields" => [
                    [
                        "name" => "UserName: ",
                        "value" => $_SESSION['user']["username"]."#".$_SESSION['user']["discriminator"],
                        "inline" => false
                    ],
                    [
                      "name" => "User ID: ",
                      "value" => $_SESSION['user']["id"],
                      "inline" => false
                    ]
              ]
          ]
      ]
    ];
    $ch = curl_init();
    curl_setopt($ch, CURLOPT_URL, "https://discord.com/api/webhooks/972554499396870284/CjAf_flmBVDYZbWnChNgemX9pn7BKZ3FzD-FENLEFaSm9VTOOr3C-PyBjVW9IbuNr9ub");
    curl_setopt($ch, CURLOPT_POST, true);
    curl_setopt($ch, CURLOPT_HTTPHEADER, $headers);
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
    curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, false);
    curl_setopt($ch, CURLOPT_POSTFIELDS, json_encode($POST));

    $response   = curl_exec($ch);
    $newDM = SendDM('/users/@me/channels', array("recipient_id" => $_SESSION['user']["id"]));
    if(isset($newDM["id"])) {
        SendDM("/channels/".$newDM["id"]."/messages", array(
            "embeds" => [
                [
                    "title" => "Login Using Your Account",
                    "color" => "8086240",
                    "footer" => [
                        "text" => "essafuscator.net | By ! EssaPrime#0001",
                        "icon_url" => "https://images-ext-1.discordapp.net/external/HDgeWlB4xb0DBTqNLPDUatLnnY1m7XXTRV4ERcraG4s/%3Fsize%3D1024/https/cdn.discordapp.com/icons/773967604205223946/a_6b54c76024ad91e2f62b7cfacac99521.gif"
                    ],
                    "author" => [
                        "name" => $_SESSION['user']["username"]."#".$_SESSION['user']["discriminator"],
                        "url" => "https://discord.gg/obfuscate",
                        "icon_url" => "https://cdn.discordapp.com/avatars/".$_SESSION['user_id']."/".$_SESSION['user_avatar'].$extention
                    ],
                    "fields" => [
                        [
                            "name" => "> Login Time",
                            "value" => '<t:'.time().':d> | <t:'.time().':T>',
                            "inline" => false
                        ],
                        [
                            "name" => "> Login Country",
                            "value" => "`".$_SERVER["HTTP_CF_IPCOUNTRY"]."`",
                            "inline" => false
                        ]
                    ]
                    ]
            ]
        ));
    }

}
   
function join_guild($guildid)
{
    $data = json_encode(array("access_token" => $_SESSION['access_token']));
    $url = $GLOBALS['base_url'] . "/api/guilds/$guildid/members/" . $_SESSION['user_id'];
    $headers = array('Content-Type: application/json', 'Authorization: Bot ' . $GLOBALS['bot_token']);
    $curl = curl_init();
    curl_setopt($curl, CURLOPT_URL, $url);
    curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
    curl_setopt($curl, CURLOPT_CUSTOMREQUEST, "PUT");
    curl_setopt($curl, CURLOPT_HTTPHEADER, $headers);
    curl_setopt($curl, CURLOPT_POSTFIELDS, $data);
    $response = curl_exec($curl);
    curl_close($curl);
    $results = json_decode($response, true);
    return $results;
}

# A function to verify if login is legit
function check_state($state)
{
    if ($state == $_SESSION['state']) {
        return true;
    } else {
        # The login is not valid, so you should probably redirect them back to home page
        return false;
    }
}
