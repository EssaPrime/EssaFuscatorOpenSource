<?php   

    if(isset($_POST["submit"])) { 
        if(!isset($_SESSION)) 
        { 
            session_start(); 
        } 
        
        if (!isset($_SESSION["user"])) {
            $resMessage = array(
                "status" => "alert-danger",
                "message" => "Unexpected Error, Contact Essa \n\n ايرور غير متوقع, تواصل مع عيسى."
            );
            return; 
        }
        
        if (!file_exists($_FILES["fileUpload"]["tmp_name"])) {
           $resMessage = array(
               "status" => "alert-danger",
               "message" => "You Have To Put A File \n\n لازم تحط ملف."
           );
           return;
        } else {
            $postdata = json_encode(
                array(
                    'script' => file_get_contents($_FILES["fileUpload"]["tmp_name"]), // Script
                    'watermark' => $_POST["wotahmark"] // Watermark
                )
            );
            
            $opts = array('http' =>
                array(
                    'method'  => 'POST',
                    'header'  => array(
                        'Content-Type: application/json',
                        'EssaFuscatorAPIKey: ESSA-'.$_SESSION["user"]["id"]
                    ),
                    'content' => $postdata,
                    'ignore_errors' => true
                )
            );
            $context  = stream_context_create($opts);
            $result = file_get_contents('http://api.essafuscator.net/v2/obfuscate/'.$_POST["byteskin"], false, $context);
            $status_line = $http_response_header[0];
            preg_match('{HTTP\/\S*\s(\d{3})}', $status_line, $match);

            $status = $match[1];
            // 
            if ($status == 400) {
                
                $resMessage = array(
                    "status" => "alert-danger",
                    "message" => "There Was An Error While Obfuscating: [".json_decode($result,true)["error"]."]"
                );
                return;
            }elseif($status == 200){
                /*
                $epoch = time();
                $filepath = "obfuscated/EFuscated-".$epoch.".lua";
                $myfile = fopen($filepath, "w") or die("Unable to open file!");

                fwrite($myfile, json_decode($result,true)['obfscript']);
                fclose($myfile);

                if (file_exists($filepath)) {
                    header('Content-Description: File Transfer');
                    header('Content-Type: application/octet-stream');
                    header('Content-Disposition: attachment; filename="' . basename($filepath) . '"');
                    header('Expires: 0');
                    header('Cache-Control: must-revalidate');
                    header('Pragma: public');
                    header('Content-Length: ' . filesize($filepath));
                    readfile($filepath);
                    flush();
                    exit;
                }*/
                $resMessage = array(
                    "status" => "alert-success",
                    "message" => "File Obfuscated Successfully."
                );
                header("Location: ".str_replace("?json=true","?json=false",json_decode($result,true)['cdnlink']));
                exit();
                return;
            }else{
                $resMessage = array(
                    "status" => "alert-danger",
                    "message" => "There Was An Unknown Error, Contact ! EssaPrime#0001 On Discord!"
                );
                return;
            }     
                            
        }
           
    }
?>