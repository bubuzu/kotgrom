var sliderH = 130;
var slideCount = 4;
var curslide = 0;
var slidesShown = 3;

var BigImageUrl = undefined;

function slideDown() {
    if (slideCount < 3) {
        return;
    }

    curslide = curslide + slidesShown;

    if (curslide > slideCount - slidesShown) {
        curslide = slideCount - slidesShown;
    }

    Setbuttons();

    $("#SliderContainer").animate({
        top: -(curslide * sliderH)
    }, 500, function () {
    });
}

function slideUp() {
    curslide = curslide - slidesShown;

    if (curslide < 0) {
        curslide = 0;
    }

    Setbuttons();

    $("#SliderContainer").animate({
        top: -(curslide * sliderH)
    }, 500, function () {
    });
}

function fillSlider(images) {
    $("#SliderContainer").css("top", 0);
    curslide = 0;
    var imarr = images.split(";");
    $("#SliderContainer").empty();
    slideCount = 0;
    for (var i = 0; i < imarr.length; i++) {
        if (imarr[i] != "") {
            slideCount++;
            var bgimage = "captured/small/" + imarr[i];
            
            if (i == 0) {
                BigImageUrl = imarr[i];
                $('#BigImage').css('background-image', "url(captured/big/" + imarr[i] + ")");
                $("#SliderContainer").append("<div class='sliderImage Shadowed' style='background-image:url(" + bgimage + ")'  onclick=\"SetBigImage('" + imarr[i] + "', this)\"/></div>");
            } else {
                $("#SliderContainer").append("<div class='sliderImage' style='background-image:url(" + bgimage + ")'  onclick=\"SetBigImage('" + imarr[i] + "', this)\"/></div>");
            }
        }
    }

    Setbuttons();
    //PostToVk('/captured/big/a7f4959a-a168-4e89-8a0b-7d22a70dc72f.jpg', 1);
    //Share.facebook("http://kotavdom.ru/", "Кот в дом", "http://kotavdom.ru/captured/big/99e86769-4065-443e-b165-f194a7031941.jpg", "Этот кот ищет свой дом");

    //PostToFb("99e86769-4065-443e-b165-f194a7031941.jpg", 1);
}

function SetBigImage(imagename, owner) {
    $("#SliderContainer").children().removeClass("Shadowed");
    if (owner != undefined) {
        $(owner).addClass("Shadowed");
    }
    BigImageUrl = imagename;
    $('#BigImage').fadeTo('fast', 0.3, function () {
        $(this).css('background-image', "url(captured/big/" + imagename + ")");
    }).fadeTo('fast', 1);
}

function Setbuttons() {
    if (curslide > 0) {
        SetButtonEnabled(true, "#SliderUpButton", "upbutton");
    } else {
        SetButtonEnabled(false, "#SliderUpButton", "upbutton");
    }
    
    if (curslide < slideCount - slidesShown) {
        SetButtonEnabled(true, "#SliderDownButton", "downbutton");
    } else {
        SetButtonEnabled(false, "#SliderDownButton", "downbutton");
    }
    
}