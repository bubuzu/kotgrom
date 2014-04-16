//var sliderH = 130;
//var slideCount = 4;
//var curslide = 0;
//var slidesShown = 3;

var slidelen = 400;
var curpos = 0;
var h = 0;

function slideDown() {
    
   
        //curslide = curslide + slidesShown;

        //if (curslide > slideCount - slidesShown) {
        //    curslide = slideCount - slidesShown;
        //}

        //$("#SliderContainer").animate({
        //    top: -(curslide * sliderH)
        //}, 500, function () {
    //});
    h = 0;
    if (navigator.appName == 'Netscape' || navigator.appName == 'Microsoft Internet Explorer') {
        $("#SliderContainer img").each(function () {
            h += $(this).height() + 14;
        });
        SetButtonEnabled(slidelen <= h, "#SliderDownButton", "downbutton");
    }
    
    var maxpos = -h + slidelen;
    
    if (maxpos >= 0) {
        return;
    }

    $("#SliderUpButton").fadeIn();
    curpos -= slidelen;
    if (curpos < maxpos) {
        curpos = maxpos;
        SetButtonEnabled(false, "#SliderDownButton", "downbutton");
    }
    
    $("#SliderContainer").animate({
        top: curpos
    }, 500, function () {
    });

    SetButtonEnabled(true, "#SliderUpButton", "upbutton");

}

function slideUp() {
    
    if (slidelen >= h) {
        return;
    }

    curpos += slidelen;

    if (curpos > 0) {
        curpos = 0;
        SetButtonEnabled(false, "#SliderUpButton", "upbutton");
    } 

    $("#SliderContainer").animate({
        top: curpos
    }, 500, function () {
    });

    if (slidelen < h) {
        SetButtonEnabled(true, "#SliderDownButton", "downbutton");
    }
}

function fillSlider(images, selectlast) {

    var imarr = images.split(";");
    var slideCount = imarr.length;
    
    if (slideCount == 0) {
        return;
    }

    var pic = imarr[0];

    $("#SliderContainer").empty();

    var texttoappend = "";
    for (var i = 0; i < slideCount; i++) {
        if (imarr[i] != "") {
            texttoappend += "<div class='sliderImage'><img src='captured/small/" + imarr[i] + "'  onclick=\"SetBigImage('" + imarr[i] + "', this)\"/></div>";
        }
    }
    h = 0;

    $("#SliderContainer").append(texttoappend);
    $("#SliderContainer").css("top","0");

    var imjs = $("#SliderContainer img");
    var z = 0;
    var len = imjs.length;

    var first  = imjs[0];

    for (var j = 0; j < imjs.length; j++) {
        $(imjs[j]).on('load', function ()
        {
            z++;
            if (navigator.appName == 'Netscape' || navigator.appName == 'Microsoft Internet Explorer') {
                h += $(this).height() + 14;
            } else {
                //h += this.clientHeight + 14;
                h += $(this).height() + 14;
            }

            if (z == len) {
                
                h += 10;
                SetButtonEnabled(false, "#SliderUpButton", "upbutton");
                SetButtonEnabled(slidelen <= h, "#SliderDownButton", "downbutton");
                SetBigImage(pic, first);
            }
        });
    }

    
    
}

function SetBigImage(imagename, owner) {
    $("#SliderContainer img").removeClass("Shadowed");
    $(owner).addClass("Shadowed");

    $('#BigImage').fadeTo('fast', 0.3, function () {
        $(this).css('background-image', "url(captured/big/" + imagename + ")");
        //$("#BigImage").empty();
        //$("#BigImage").append("<img class='ShadowedWhite' src='captured/big/" + imagename + "'/>");
        //$("#BigImage").append("<img src='images/photobottom.png'/>");

        //$("#BigImage img").on("load", function () {
        //    var bh = (470 - $("#BigImage img").height()) / 2;
        //    if (bh < 230) {
        //        $("#BigImage").css("margin-top", bh);
        //    }
        //});
    }).fadeTo('fast', 1);
}