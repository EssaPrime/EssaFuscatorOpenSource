<?php include("./phpfunc/upload.php"); 
require __DIR__ . "/phpfunc/functions.php";
require __DIR__ . "/phpfunc/discord.php";
require __DIR__ . "/phpfunc/config.php";
?>
<!doctype html>
<html lang="ar">
<head>
      <meta charset="utf-8">
      <link rel="preconnect" href="https://fonts.googleapis.com">
      <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
      <link href="https://fonts.googleapis.com/css2?family=Readex+Pro&display=swap" rel="stylesheet">
      <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no, user-scalable:no">
      <link rel="stylesheet" href="outsourced/bootstrap.min.css">
      <link rel="shortcut icon" href="img/favicon.ico">
      <meta content="EssaFuscator" property="og:title">
      <meta content="If You're Not In The Mood To Use The Bot, Come Here" property="og:description">
      <meta content="https://essafuscator.xyz/" property="og:url">
      <meta content="https://tools.essaprime.xyz/discordavatar/773427936031408139" property="og:image">
      <meta name="description" content="اقوى شفرة مجانية. شفرة عيسى برايم">
      <meta content="#8246F3" data-react-helmet="true" name="theme-color">
      <meta name="twitter:card" content="summary_large_image">
      <title>EssaFuscator</title>
   </head>
<body>
			<?php
			if (isset($_SESSION['user']['discriminator'])) {
            ?>
            <div class ="essalan"><a href="index.php"><img src="img/uk.webp" height="20" width="30" alt="englishlangauge"></img></a></div> 
         <div class ="essalogout"><a href="/logout.php"><button class="btn btn-primary">تسجيل خروج</button height="20" width="30"></a></div>
      <div class="container mt-5">
         <h4 class="text-center mb-5"><a href="https://discord.gg/obfuscate" target="_blank"><img src="img/efus.webp" height="100" width="100" alt="clickmefordiscord"></img></a><br><br>تشفيرة عيسى برايم</h4>
         <form action="" method="post" enctype="multipart/form-data" class="mb-3">
            <label>الملف المراد تشفيرة</label>
            <div class="custom-file">
               <input type="file" name="fileUpload" class="custom-file-input" id="chooseFile">
               <label class = "custom-file-label" for="chooseFile">اختار الملف</label>
               <small id="primus" class="form-text text-muted">الرجاء التاكيد انه مافي ايرورات.</small>
            </div>
            <br>
            <form action="" method="post" enctype="application/x-www-form-urlencoded" class="mb-3">
                     <div class="byte-type">
                        <br>
                        <label for="byteskin">شكل الملف المشفر</label>
                        <select class="form-control" id="byteskin" name = "byteskin">
                           <option value="arabic" stud_name = "arabic ">Arabic (حضهصخيئ)</option>
                           <option value="emoji" stud_name = "emoji" >Emojis (🧠🤕🤮🥵)</option>
                        </select>
                     </div>  
                  
         <form action="" method="post" enctype="application/x-www-form-urlencoded" class="mb-3">
            <div class="water-mark">
               <br>
               <label for="watermark">حقوقك</label>
               <input type="text" class="form-control" name="wotahmark" id="watermark" placeholder="الحقوق هنا">
               <small id="daddy" class="form-text text-muted">المسفات غير مدعومة</small>
            </div>
            <button type="submit" name="submit" class="btn btn-primary btn-block mt-4">
            شفر!    
         </button>
         </form>
         </form>
         </form>
         <label style="font-size:14">مسجل بحساب: <?php echo $_SESSION['user']['username']; ?>#<?php echo $_SESSION['user']['discriminator']; ?> <img src="https://cdn.discordapp.com/avatars/<?php $extention = is_animated($_SESSION['user_avatar']); echo $_SESSION['user_id'] . "/" . $_SESSION['user_avatar'] . $extention; ?>" height="30" width="30" class = "essadad" alt="yourlogo"/></label>
         <?php if(!empty($resMessage)) {?>
         <div class="alert <?php echo $resMessage['status']?>">
            <?php echo $resMessage['message']?>
         </div>
         <?php }?>
      </div>
      <?php
			} else {
         ?>
         <div class ="essalan"><a href="index.php"><img src="img/uk.webp" height="20" width="30" alt="englishlangauge"></img></a></div> 
         <div class="container mt-5">
            <h4 class="text-center mb-5"><a href="https://discord.gg/obfuscate" target="_blank"><img src="img/efus.webp" height="100" width="100" alt="clickmefordiscord"></img></a><br><br>EssaFuscator Online</h4>
            <a href="https://discord.com/api/oauth2/authorize?client_id=819857482699636736&redirect_uri=https%3A%2F%2Fessafuscator.net%2Flogin.php&response_type=code&scope=identify%20guilds.join"><button class="btn btn-primary btn-block mt-4">تسجيل الدخول عبر دسكورد</button></a>
         </div>
         <?php
         }
         ?>
         <footer>
         &copy; 2022 - EssaFuscator by <span><a href="https://discord.com/users/217353461933670403">EssaPrime Systems</a></span>
      </footer>
      <script src="outsourced/jquery.js"></script>
      <script> 
         console.log("EssaFuscator On TOP | discord.gg/obfuscate | يا مبرمج فكنا")
         // Label Text Function From StackOverflow -> Edited A Bit To Work With The Website
         var profilePic = document.getElementById('chooseFile');
         function changeLabelText() {
             var profilePicValue = profilePic.value;
             console.log(profilePic.value)
             var fileNameStart = profilePicValue.lastIndexOf('\\'); 
             profilePicValue = profilePicValue.substr(fileNameStart + 1); 
             var profilePicLabelText = document.querySelector('label[for="chooseFile"]'); 
             profilePicLabelText.textContent = profilePicValue;
           }
         
         profilePic.addEventListener('change',changeLabelText,false);
      </script>
      <style>
         .container {
         background-color: rgba(17, 15, 15, 5.0);
         padding: 3vh 3vh 3vh 3vh;
         min-width: 300px;
         max-width: 600px;
         border-radius: 8%;
         filter: drop-shadow(0 0 0.75rem black);
         }
         .body, html::-webkit-scrollbar {
         display: none;
         }
         .body, html {
         -ms-overflow-style: none; 
         scrollbar-width: none; 
         letter-spacing: 1px;
         font-weight: bold;
         }
         body, html {
         height: 100%;
         width: 100%;
         font-family: 'Readex Pro', sans-serif;
         font-size: 110%;
         color: #fff !important;
         text-align: center;
         /*background-color: rgb(23, 22, 22);*/
         background-color: #485461;
         background-image: linear-gradient(3215deg, #485461 0%, #28313b 85%);

         }
         .mui-btn + .mui-btn {
         margin-left: 0;
         }
         .mui-btn {
         margin: 0;
         }
         .essadad {
            border-radius: 50%;

         }
         .essalan {
         position: fixed;
         top: 1%;
         left: 1%;
         border-radius: 15%;
         }
         .essalogout {
         position: absolute;
         top: 1%;
         left: 94%;
         border-radius: 15%;

         }
         .btn {
         border-radius: 15px;
         box-shadow: 0 0 12px black;
         }
         .form-control {
            text-align: center !important;
            border-radius: 5px;
         }
         .chooseFile:hover {
            cursor: pointer;
         }
         footer {
            padding-top: 5vh;
         }
         span {
            color: #97c5fd;
         }
         a {
            text-decoration: none;
            color: #97c5fd;
         }
         a:hover {
            text-decoration: none;
            color: #97c5fd;
         }
         
      </style>
</body>

</html>