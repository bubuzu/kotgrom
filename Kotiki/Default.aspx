<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Kotiki.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Взять кота. Кот Гром и заколдованный дом.</title>
    
    <meta property="og:title" content="Взять кота. Кот Гром и заколдованный дом." />
    <meta property="og:image" content="http://kotavdom.ru/images/logo.jpg" />
    <meta property="og:description" content="Помогите найти котику свой дом." />
    
    <meta name="title" content="Взять кота. Кот Гром и заколдованный дом." />
    <meta name="description" content="Помогите найти котику свой дом." />
    <link rel="image_src" href="http://kotavdom.ru/images/logo.jpg" />

    <link href="main.css" rel="stylesheet"/>
    <link href="fileupload.css" rel="stylesheet" />
    <link href="slider2.css" rel="stylesheet" />
    <link href="fonts.css" rel="stylesheet" />
    <link href="pager.css" rel="stylesheet" />
    
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="js/common.js"></script>
    <script src="js/fileuploader.js" type="text/javascript"></script>
    <script src="js/main.js"></script>
    <script src="js/slider2.js"></script>
    <script src="js/paginator.js"></script>
    <script src="js/fbfileselect.js"></script>
    <script src="js/Share.js"></script>

    <script>
        var uid = <%=Uid%>;
        var isAdmin = <%=IsAdmin%>;
        var sessid = <%=Sessid%>;
        var userid = <%=UserId%>;
        var token = <%=Token%>;
        var socialtype = <%=SocialType%>;
        var startAid = <%=Aid%>;
    </script>
    <script type="text/javascript" src="https://vk.com/js/api/share.js?90" charset="windows-1251"></script>
</head>
<body>
   <script>
       window.fbAsyncInit = function() {
          FB.init({
               appId      : '<%=FbAppId %>',
               status     : true,
               xfbml      : true
           });
       };

       (function(d, s, id){
           var js, fjs = d.getElementsByTagName(s)[0];
           if (d.getElementById(id)) {return;}
           js = d.createElement(s); js.id = id;
           js.src = "//connect.facebook.net/en_US/all.js";
           fjs.parentNode.insertBefore(js, fjs);
       }(document, 'script', 'facebook-jssdk'));
       
       
       window.vkAsyncInit = function() {
           VK.init({
               apiId: <% = VkAppId %>
           });
       };

       setTimeout(function() {
           var el = document.createElement("script");
           el.type = "text/javascript";
           el.src = "//vk.com/js/api/openapi.js";
           el.async = true;
           document.getElementById("vk_api_transport").appendChild(el);
       }, 0);
    </script>
    <div id="fb-root"></div>
     <div id="vk_api_transport"></div>
    <form id="form1" runat="server">
    <div id="Main">
        <a id="top_link" href="http://www.kotgrom.ru" target="_blank"></a>
    	<a id="bottom_link" href="http://www.kotgrom.ru" target="_blank"></a>
        <%--<div id="HowToGetButton" onclick="ShowHowToGet();"></div>
        <div id="HowToGiveButton"  onclick="ShowHowToLive();"></div>--%>
        
        <div id="HowToGiveGetButton">
            <div id="HowToGiveButton2" onclick="ShowHowToLive();" ></div>
            <div id="HowToGetButton2" onclick="ShowHowToGet();"></div>
        </div>
        <div id="HowTo">
          <div id="HowToGet" style="display: none">
          <table style="width: 100%;" class="howtoget">
              <tr>
                  <td colspan="3" class="column0">Как взять котенка домой?<br/><br/><span style="font-size: 16pt; height: 20px;">Взять котенка домой может любой желающий. Для этого:</span></td>
              </tr>
              <tr>
                  <td class="column2"><div class="numberCircle">1</div></td>
                  <td class="column3">Выберите самую очаровательную по Вашему мнению мордочку на нашем сайте</td>
              </tr>
              <tr>
                  <td class="column2"><div class="numberCircle">2</div></td>
                  <td class="column3">Кликните по фотографии и узнайте контакты, по которым можно связаться и забрать пушистого питомца</td>
              </tr>
          </table>
      </div>
        
      <div id="HowToLive">
          <%--<table style="width: 100%; height: 211px;" class="howtoget">
              <tr>
                  <td colspan="3" class="column0">Как пристроить котенка?</td>
              </tr>
              <tr>
                  <td class="column2"><div class="numberCircle">1</div></td>
                  <td class="column3">Разместите информацию о котике в онлайн-приюте «Возьми кота».</td>
              </tr>
              <tr>
                  <td class="column2"><div class="numberCircle">2</div></td>
                  <td class="column3">Добавьте «личное дело» усатого на нашем сайте.</td>
              </tr>
              <tr>
                  <td class="column2"><div class="numberCircle">3</div></td>
                  <td class="column3">Как только найдутся добрые хозяева, Вы узнаете об этом первым. Просто передайте котика им и порадуйтесь за него.</td>
              </tr>
          </table>--%>
          <img src="images/howtoget.png"/>
      </div>
        </div>

    <div id="CatCount"></div>
    <div id="GiveButton" onclick="ShowLogin(uid);" 
        onmouseover="$(this).css('background-image','url(images/btnCreate_h.png)')"
        onmouseout="$(this).css('background-image','url(images/btnCreate.png)')"/></div>
        
     <div id="LoginDiv">
               <div id="LoginClose" onclick="HideLogin();"></div>
               <div id="LoginButtons">
                    <a id="FbLoginButton" href="https://www.facebook.com/dialog/oauth?client_id=<%=FbAppId %>&redirect_uri=<%=FbRedirectUri %>&response_type=code&scope=user_photos"></a>
                    <a id="VkLoginButton" href="http://oauth.vk.com/authorize?client_id=<%=VkAppId %>&redirect_uri=<%=VkRedirectUri %>&response_type=code&scope=photos,wall"></a>
                </div>
            </div>   
     <div id="DarkPage"></div>
    
     <div id="AddCatDiv">
         <div id="CloseAddCat" onclick="CloseAddDiv();"></div>
         <div id="Photos">
             <div id="BigImage">
                 <div id="ShareButton" onclick="ShareImage(socialtype,BigImageUrl,AdvertId)"></div>
                 <div id="FindLabel"></div>
             </div>
             <div id="ImageSelector">
                 <div id="SliderUpButton" onclick="slideUp();"></div>
                 <div id="Slider">
                     <div id="SliderContainer">
                     </div>
                 </div>
                 <div id="SliderDownButton" onclick="slideDown();"></div>
             </div>
         </div>

         <div id="AddCatImageButton" onclick="ShowFileSelector();" onmouseover="$(this).toggleClass('hover')" onmouseout="$(this).toggleClass('hover')"></div>
         <div id="ReadyCatButton" onclick="saveAdvert(uid, sessid, $('#txtPhone').val(), $('#txtEmail').val(), $('#txtCity').val(),$('#txtDescription').val())" onmouseover="$(this).toggleClass('hover')" onmouseout="$(this).toggleClass('hover')"></div>
     
         <div id="DescriptionDiv">
             <div id="DescriptionText">Описание:</div>
             <div id="DescriptionValue"><textarea id="txtDescription" placeholder="Описание вашего любимца"></textarea></div>
         </div>

         <div id="EditsDiv">
             <div id="ContactsText">Ваши контакты</div>
             <div id="ContactsPhone"><input id="txtPhone" placeholder="Ваш номер телефона"/></div>
             <div id="ContactsEmail"><input id="txtEmail" placeholder="Ваш E-mail"/></div>
             <div id="ContactsCity"><input id="txtCity" placeholder="Ваш город"/></div>
         </div>
         
         <div id="WindowHeader">Пристроить кота</div>
         <div id="cbGave"  onclick="CbFindClick();"></div>
         
         <div id="btnDelete" onclick="DeleteAdvert(sessid);">Удалить</div>
     </div>
        
     <div id="FilesLoadPopup">
        <div id="FileUpload">
            <div id="files"></div>
            <input type="file" id="fileSelector"/>
        </div>
        <div id="SocialFile" onclick="ShowSocialFileSelector(socialtype);"></div>
         <div id="FilesPopupClose" onclick="CloseFileSelector();"></div>
     </div>
    
    <div id="SocialLoadPopup">
        <div id="SocialPopupClose" onclick="CloseSocialFileSelector()"></div>
        <div id="SocialPopupSlider">
             <div id="btnSocialLeft" onclick="SocPreClick(socialtype);"></div>
             <div id="SocialImages"></div>
            <div id="btnSocialRight" onclick="SocNextClick(socialtype);"></div>
        </div>
        <div id="SocialPopupOk" style="display: none;" onclick="SaveSocialImage();"></div>
    </div>
        
    <div id="GalleryFilter">
        <div id="FilterMy" class="filterItem" style="width: 55px" onclick="if (uid != undefined) { getpage(1,'my');changeFilter(this);} else {ShowLogin(uid);}">Мои</div>
        <div id="FilterGeted" class="filterItem" onclick="getpage(1,'ready');changeFilter(this);">Уже взяли</div>
        <div id="FilterAll" class="filterItem selected" onclick="getpage(1,'all');changeFilter(this);">Все</div>
    </div>

     <div id="Gallery"></div>
    
     <div id="Pager">
         <div id="PagerChild">
        </div> 
     </div>   
      
    <div id="SocialShare">
        <div id="VkShare">
          <script type="text/javascript">
            document.write(VK.Share.button(false,{type: "round", text: "Сохранить"}));
           </script>
        </div>
        <div id="FbShare">
            <div class="fb-share-button" data-href="http://kotavdom.ru/" data-type="button_count"></div>
        </div>
        <div id="TwShare">
            <a href="https://twitter.com/share" class="twitter-share-button" data-lang="ru">Твитнуть</a>
<script>!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0],p=/^http:/.test(d.location)?'http':'https';if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=p+'://platform.twitter.com/widgets.js';fjs.parentNode.insertBefore(js,fjs);}}(document, 'script', 'twitter-wjs');</script>
        </div>
    </div>
     
    </form>
        <script type="text/javascript">
            $("document").ready(function(){
                $('#fileSelector').on("change", function(){
                    var file = document.getElementById("fileSelector").files[0];
                    uploadfile('', file);
                });
            });

            getpage(1);
            //ShowHowToGet();
            InitEvents();
        
            if (startAid != undefined) {
                ShowViewDiv(startAid);
            }
            
            if (sessid != undefined) {
                ShowAddDiv();
            }
    </script> 
    
    <script>
        (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
            (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
            m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
        })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

        ga('create', 'UA-50073208-1', 'kotavdom.ru');
        ga('send', 'pageview');

</script>
    
</body>

</html>
