<?php

include_once __DIR__.'/SlackBot.php';
include_once __DIR__.'/SlackBotInfo.php';

if ( $argc < 2 ) {
    $message = date("Y/m/d H:i:s");
} else {
    $message = $argv[1];
}

$url = "https://hooks.slack.com/services/XXX/XXX/XXX";
// メッセージをポスト
$bot = new SlackBot();
print_r($bot->post_message(new SlackBotInfo($url, $message)));
