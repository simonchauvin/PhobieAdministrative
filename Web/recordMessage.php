<?php 
$mask = "message_*.*";
foreach (glob($mask) as $filename) {
    unlink($filename);
}
$error = $_FILES["message"]["error"];
if ($error == UPLOAD_ERR_OK) {
	$tmp_name = $_FILES["message"]["tmp_name"];
	$name = $_FILES["message"]["name"];
	move_uploaded_file($tmp_name, "$name");
}
?>