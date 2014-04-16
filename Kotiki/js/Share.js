Share = {
    vkontakte: function (purl, ptitle, pimg, text) {
        url = 'http://vkontakte.ru/share.php?';
        url += 'url=' + encodeURIComponent(purl);
        url += '&title=' + encodeURIComponent(ptitle);
        url += '&description=' + encodeURIComponent(text);
        url += '&image=' + encodeURIComponent(pimg);
        url += '&noparse=true';
        Share.popup(url);
    },
    facebook: function (purl, ptitle, pimg, text) {
        url = 'https://www.facebook.com/dialog/feed';
        url += '&p[title]=' + encodeURIComponent(ptitle);
        url += '&p[summary]=' + encodeURIComponent(text);
        url += '&p[url]=' + encodeURIComponent(purl);
        url += '&p[images][0]=' + encodeURIComponent(pimg);
        Share.popup(url);
    },

    popup: function (url) {
        window.open(url, '', 'toolbar=0,status=0,width=626,height=436');
    }
};


function ShareFb(sessid, pic, link, text, desc) {

    if (!erroronshare) {

        $.post("ajax.ashx?p=wallfb&sessionId=" + sessid + "&pic=" + pic + "&link=" + link, {}, function (r) {
            if (r == "true") {
                CloseDiv('#ShareDiv');
                ShowTextDiv('Запись опубликована');
            } else {
                erroronshare = true;
                CloseDiv('#ShareDiv');
                ShowTextDiv('Не удалось опубликовать.<br>Попробуйте еще раз');
            }
        });
    } else {
        Share.facebook(link, text, pic, desc);
    }
}

//function PostToVk(id, aid) {
//    var w = 400;
//    var h = 400;

//    var left = (screen.width / 2) - (w / 2);
//    var top = (screen.height / 2) - (h / 2);
//    var wind = window.open("Wait.aspx", "_blank", 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

//    id = '/captured/big/' + id;
//    VK.api("photos.getWallUploadServer", {}, function (data) {
//        $.post("ajax.ashx?m=UploadToVK", { "uploadurl": data.response.upload_url, "imageid": id }, function (r) {
//            r = $.parseJSON(r);
//            VK.api("photos.saveWallPhoto", { "photo": r.photo, "server": r.server, "hash": r.hash }, function (data) {
                
//                //wind.location = "https://vk.com/al_apps.php?act=wall_post_box&widget=1&method=wall.post&aid=4273431&text=%D0%AD%D1%82%D0%BE%D1%82%20%D0%BA%D0%BE%D1%82%20%D0%B8%D1%89%D0%B5%D1%82%20%D1%81%D0%B2%D0%BE%D0%B9%20%D0%B4%D0%BE%D0%BC%3A%20http%3A%2F%2Fkotavdom.ru%2FDefault.aspx%3Faid%3D" + aid + "&owner_id=0&attachments=" + data.response[0].id + "&publish_date=&method_access=_84b19049";
//                VK.api("wall.post", { "message": "Этот кот ищет свой дом: http://kotavdom.ru/Default.aspx?aid=" + aid, "attachments": data.response[0].id }, function (data) {
//                    if (data.response != undefined) {
//                        //var href = "http://vk.com/id" + uid;
//                        //$("#ReadyText").html("<a href='" + href + "' target='_blank'>Вам</a> точно понравится:)");
//                        //$("#ReadyDiv").fadeIn();
//                        //$.post("ajax.ashx?m=Shared", { "uid": uid, "fid": uid, "pic": imageid }, function (data) { });
                        
//                    }
//                });
//            });
//        });
//    });
    
//    ga('send', 'event', 'share', 'PostToVk');
//}

function PostToVk(id, aid) {
    var w = 400;
    var h = 400;

    var left = (screen.width / 2) - (w / 2);
    var top = (screen.height / 2) - (h / 2);
    var wind = window.open("http://vk.com/share.php?url=http://kotavdom.ru?aid=" + aid + "&image=http://kotavdom.ru/captured/big/" + id + "&title=%D0%92%D0%BE%D0%B7%D1%8C%D0%BC%D0%B8%20%D0%BA%D0%BE%D1%82%D0%B0&description=%D0%AD%D1%82%D0%BE%D1%82%20%D0%BA%D0%BE%D1%82%20%D0%B8%D1%89%D0%B5%D1%82%20%D1%81%D0%B2%D0%BE%D0%B9%20%D0%B4%D0%BE%D0%BC&noparse=true", "_blank", 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

    ga('send', 'event', 'share', 'PostToVk');
}



function PostToFb(id, aid) {
    
  FB.ui(
  {
      method: 'feed',
      name: 'Кот Гром',
      link: 'http://kotavdom.ru/Default.aspx?aid='+aid,
      picture: 'http://kotavdom.ru/captured/big/' + id,
      caption: 'Кота в дом',
      description: 'Этот кот ищет свой дом'
  },
  function (response) {
      //if (response && response.post_id) {
      //    alert('Post was published.');
      //} else {
      //    alert('Post was not published.');
      //}
  });
    
  ga('send', 'event', 'share', 'PostToVk');
}

function ShareImage(socialtype, id, aid) {
    //if (socialtype == undefined) {
    //    ShowLogin();
    //    return;
    //}

    if (socialtype == "vk") {
        PostToVk(id, aid);
    } else {
        PostToFb(id, aid);
    }
}