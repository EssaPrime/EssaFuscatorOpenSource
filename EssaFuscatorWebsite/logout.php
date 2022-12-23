<?php
require __DIR__ . "./phpfunc/functions.php";
session_start();
session_destroy();
redirect("../index.php");
?>
