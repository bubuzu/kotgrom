var fbNextQ = undefined;
var fbPreQ = undefined;
var socialPicUrl = undefined;

function fbFileNext() {
    FB.api(fbNextQ, function (resp) {
        parceResponse(resp);
    });
}

function fbFilePre() {
    FB.api(fbPreQ, function (resp) {
        parceResponse(resp);
    });
}

function fbFileSelect() {
    //100000427003914/photos?limit=5&type=tagged&until=
    FB.api('me/photos?limit=4', function (resp) {
        parceResponse(resp);
    });
}

function parceResponse(resp) {
    socialPicUrl = undefined;
    
    fbPreQ = resp.paging.next;
    fbNextQ = resp.paging.next;

    $("#SocialImages").empty();
    $("#SocialPopupOk").fadeOut("fast");

    for (var i = 0; i < resp.data.length; i++) {

        var curIm = resp.data[i].images[0];
        var bigIm = resp.data[i].images[0];
        var maxWidth = resp.data[i].images[0].width;

        for (var j = 0; j < resp.data[i].images.length; j++) {
            if (resp.data[i].images[j].width < 200) {
                curIm = resp.data[i].images[j];
                break;
            }
        }
        
        for (var j = 0; j < resp.data[i].images.length; j++) {
            if (resp.data[i].images[j].width > maxWidth) {
                bigIm = resp.data[i].images[j];
                maxWidth = bigIm.width;
            }
        }

        var params = 'this,"' + bigIm.source + '"';
        var str = "<div class='SocialImage' style='background-image:url(" + curIm.source + ")' onclick='ChangeSelection(" + params + ")'/>";
        //if (i == 0) {
        //    str = "<div class='SocialImage selected' style='background-image:url(" + curIm.source + ") onclick='ChangeSelection(" + params + ")'/>";
        //    socialPicUrl = curIm.source;
        //}
        
        $("#SocialImages").append(str);
    }
}

function ChangeSelection(owner, newUrl) {
    if (socialPicUrl == undefined) {
        $("#SocialPopupOk").fadeIn("fast");
    }
    socialPicUrl = newUrl;
    $("#SocialImages").children().removeClass("selected");
    $(owner).addClass("selected");
}

function SaveSocialImage() {
    if (socialPicUrl != undefined) {
        $.post("ajax.ashx", { m: "loadfromweb", fileurl: socialPicUrl }, function (e) {
            var response = $.parseJSON(e);

            Images += response.name + ";";
            CheckAdvertReady();

            fillSlider(Images, true);
        });
    }
}

// VK PART
var VkOffset = 0;
var VkTotal = 0;

function vkFileSelect() {
    VK.Api.call('photos.get', { album_id: "wall", count: 4, offset: VkOffset, v:"5.21" }, function (r) {
        if (r.response) {
            parceVkResponse(r.response);
        }
    });
}

function parceVkResponse(resp) {
    socialPicUrl = undefined;

    $("#SocialImages").empty();
    $("#SocialPopupOk").fadeOut("fast");

    VkTotal = resp.count;

    for (var i = 0; i < resp.items.length; i++) {

        var curIm = resp.items[i].photo_130;
        var bigIm = resp.items[i].photo_604;

        var params = 'this,"' + bigIm + '"';
        var str = "<div class='SocialImage' style='background-image:url(" + curIm + ")' onclick='ChangeSelection(" + params + ")'/>";

        $("#SocialImages").append(str);
    }
}

function vkFileNext() {

    VkOffset += 4;

    if (VkTotal > VkOffset) {
        vkFileSelect();
    }
}

function vkFilePre() {

    VkOffset -= 4;
    if (VkOffset >= 0) {
        vkFileSelect();
    }
}