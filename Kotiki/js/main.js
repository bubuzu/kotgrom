var CurrentPage = 1;
var TotalItems = 0;
var Images = "";
var AdvertReady = false;
var PagerInited = false;
var AdvertId = undefined;
var QueryType = "all";
var CurrentClosed = false;

function ShowLogin(userid) {
    ga('send', 'event', 'login', 'LoginClick');
    if (userid == undefined) {
        $("#DarkPage").fadeIn();
        $("#LoginDiv").fadeIn();
    } else {
        ShowAddDiv();
    }
}

function HideLogin() {
    $("#DarkPage").fadeOut();
    $("#LoginDiv").fadeOut();
}

function ShowFileSelector() {
    $("#DarkPage").fadeIn();
    $("#FilesLoadPopup").fadeIn();
    $("#DarkPage").css("z-index", 28);
}

function CloseFileSelector() {
    $("#FilesLoadPopup").fadeOut();
    $("#DarkPage").css("z-index", 1);
}

function ShowSocialFileSelector(soctype) {
    $("#FilesLoadPopup").fadeOut();
    $("#SocialLoadPopup").fadeIn();
    
    if (soctype == "fb") {
        fbFileSelect();
    } else {
        vkFileSelect();
    }
}

function CloseSocialFileSelector() {
    $("#FilesLoadPopup").fadeIn();
    $("#SocialLoadPopup").fadeOut();
}

function SocNextClick(soctype) {
    if (soctype == "fb") {
        fbFileNext();
    } else {
        vkFileNext();
    }
}


function SocPreClick(soctype) {
    if (soctype == "fb") {
        fbFilePre();
    } else {
        vkFilePre();
    }
}


function ShowAddDiv() {
    AdvertId = undefined;
    SetEditMode();
    
    $("#AddCatDiv :input").val("");
    Images = "";

    $("#ShareButton").hide();
    $("#SliderContainer").empty();
    $("#BigImage").css('background-image', "");

    $("#AddCatDiv").fadeIn();
    $("#DarkPage").fadeIn();
    SetButtonEnabled(false, "#SliderDownButton", "downbutton");
    SetButtonEnabled(false, "#SliderUpButton", "upbutton");
    SetButtonEnabled(false, "#ReadyCatButton", "btnReady");
    AdvertReady = false;
    
    ga('send', 'event', 'create', 'CreateAdvertising');
}

function ShowEditDiv(aid,photos, phone, email, city, description, closed) {
    AdvertId = aid;
    SetEditMode();

    $("#cbGave").show();
    ChangeCbGave(closed);

    Images = photos;
    $("#ShareButton").show();
    $("#txtPhone").val(phone);
    $("#txtEmail").val(email);
    $("#txtCity").val(city);
    $("#txtDescription").val(decodeURI(description));

    $("#SliderContainer").empty();

    $("#AddCatDiv").fadeIn();
    $("#DarkPage").fadeIn();
    SetButtonEnabled(false, "#SliderDownButton", "downbutton");
    SetButtonEnabled(false, "#SliderUpButton", "upbutton");
    SetButtonEnabled(false, "#ReadyCatButton", "btnReady");
    
    fillSlider(photos);

    AdvertReady = true;
    CheckAdvertReady();
    
    ga('send', 'event', 'edit', 'EditCat');
}

function SetEditMode() {
    var top = $(document).scrollTop();
    $("#AddCatDiv").css("top", top);
    $("#DescriptionValue").css("overflow", "visible");

    $("#ContactsText").html("Ваши контакты");
    $("#WindowHeader").html("Пристроить кота");

    $("#ContactsPhone").html('<input id="txtPhone" placeholder="Ваш номер телефона"/>');
    $("#ContactsEmail").html('<input id="txtEmail" placeholder="Ваш E-mail"/>');
    $("#ContactsCity").html('<input id="txtCity" placeholder="Ваш город"/>');
    $("#DescriptionValue").html('<textarea id="txtDescription" placeholder="Описание вашего любимца"></textarea>');

    $("#AddCatImageButton").show();
    $("#ReadyCatButton").show();

    InitEvents();
}

function CbFindClick() {
    CurrentClosed = !CurrentClosed;
    ChangeCbGave(CurrentClosed);
}

function ChangeCbGave(check) {
    if (check == true) {
        $("#cbGave").addClass("selected");
    } else {
        $("#cbGave").removeClass("selected");
    }
}

function CloseAddDiv() {
    $("#AddCatDiv").fadeOut();
    $("#DarkPage").fadeOut();
}

function ShowHowToGet() {
    SetButtonEnabled(true, $('#HowToGiveButton'), "btnGive");
    SetButtonEnabled(false, $('#HowToGetButton'), "btnGet");

    $('#HowToLive').fadeTo('fast', 0.3, function() {
        $("#HowToGet").fadeTo('fast', 1);
    }).hide();
}

function ShowHowToLive() {
    
    SetButtonEnabled(false, $('#HowToGiveButton'), "btnGive");
    SetButtonEnabled(true, $('#HowToGetButton'), "btnGet");

    $('#HowToGet').fadeTo('fast', 0.3, function () {
        $("#HowToLive").fadeTo('fast', 1);
    }).hide();
}

function InitEvents() {
    $("#AddCatDiv :input").bind('input', function () {
        CheckAdvertReady();
    });
}

function ShowViewDiv(advid) {
    AdvertId = advid;
    var top = $(document).scrollTop();
    $("#AddCatDiv").css("top", top);

    $("#SliderContainer").empty();
    $("#ShareButton").show();
    $("#DescriptionValue").css("overflow", "auto");

    $("#AddCatDiv").fadeIn();
    $("#DarkPage").fadeIn();
    SetButtonEnabled(false, "#SliderDownButton", "downbutton");
    SetButtonEnabled(false, "#SliderUpButton", "upbutton");

    $("#AddCatImageButton").hide();
    $("#ReadyCatButton").hide();

    if (advid != undefined) {
        $("#WindowHeader").html("Взять котика");

        $.post("ajax.ashx", { m: "showadvert", advid: advid }, function(r) {
            var response = $.parseJSON(r);
            fillSlider(response.photos);

            //$("#ContactsText").html("Контакты хозяина");
            $("#ContactsText").html(response.name);
            $("#ContactsPhone").html(response.phone);
            $("#ContactsEmail").html(response.email);
            $("#ContactsCity").html(response.city);
            $("#DescriptionValue").html("<div style='width:100%'>" + response.description + "</div>");
            if (response.closed == true) {
                $("#WindowHeader").html("<span style='color:#da7533'>Этого котика уже взяли</span>");
                $("#FindLabel").show();
            } else {
                $("#WindowHeader").html("Взять котика");
                $("#FindLabel").hide();
            }
        });
    }
    
    ga('send', 'event', 'show', 'ViewCat');
}

function uploadfile(filename, file) {
    var formData = new FormData();
    formData.append(file.name, file);
    var xhr = new XMLHttpRequest();
    var url = "FileUpload.ashx";
    xhr.open('POST', url, true);
    xhr.onload = function (e) {
        var response = $.parseJSON(e.target.response);
        //console.log(response.fileName);
        //alert(response.name);

        Images += response.name + ";";
        CheckAdvertReady();

        fillSlider(Images, true);
    };
    xhr.send(formData);  // multipart/form-data
}

function changeFilter(owner) {
    $("#GalleryFilter").children().removeClass("selected");
    $(owner).addClass("selected");
}

function getpage(padeid, qtype) {
    if (qtype != undefined) {
        QueryType = qtype;
    }

    CurrentPage = padeid;
    if (QueryType == undefined) {
        QueryType = "all";
    }

    $.post("ajax.ashx", { m: "getpage", page: padeid, qtype: QueryType, uid: uid }, function (r) {
        var response = $.parseJSON(r);
        $("#Gallery").empty();

        var catnum = 0;
        TotalItems = 0;

        for (var i = 0; i < response.length; i++) {
            catnum = response[i].cats;
            TotalItems = response[0].total;
            var imarr = response[i].photos.split(";");
            
            var backImage = "captured/big/" + imarr[0];

            //ShowEditDiv(photos, phone, email, city, description)
            if (isAdmin || uid == response[i].uid) {

                var params = response[i].aid + ",'" + response[i].photos + "','" + response[i].phone + "','" + response[i].email + "','" + response[i].city + "','" + encodeURI(response[i].description) + "',"+response[i].closed;

                //if (response[i].closed == false) {
                //    $("#Gallery").append('<div class="galleryitem">' +
                //    '<img onclick="ShowEditDiv(' + params + ')" class="ShadowedLight" style="cursor:pointer;" src="captured/medium/' + imarr[0] + '"/>' +
                //    '</div>');
                   
                //} else {

                //    $("#Gallery").append('<div class="galleryitem">' +
                //   '<img onclick="ShowEditDiv(' + params + ')" style="position: relative; top:0px; left:0px; cursor:pointer; z-index:3" src="images/findhome.png"/>' +
                //   '<img onclick="ShowEditDiv(' + params + ')" class="ShadowedLight" style="position: relative;top:-52px; cursor:pointer;" src="captured/medium/' + imarr[0] + '"/>' +
                //   '</div>');
                //}
                
                if (response[i].closed == false) {
                    
                    $("#Gallery").append('<div class="galleryitem" style="background-image: url(' + backImage + ');" onclick="ShowEditDiv(' + params + ')"></div>');

                } else {

                    $("#Gallery").append('<div class="galleryitem" style="background-image: url(' + backImage + ');" onclick="ShowEditDiv(' + params + ')">' +
                   '<img onclick="ShowEditDiv(' + params + ')" style="position: relative; top:126px; left:0px; cursor:pointer; z-index:3" src="images/findhove.png"/>' +
                   '</div>');
                }
                
            } else {
                if (response[i].closed == false) {
                    $("#Gallery").append('<div class="galleryitem" style="background-image: url(' + backImage + ');"  onclick="ShowViewDiv(' + response[i].aid + ')"></div>');
                } else {
                    $("#Gallery").append('<div class="galleryitem" style="background-image: url(' + backImage + ');" onclick="ShowViewDiv(' + response[i].aid + ')">' +
                        '<img onclick="ShowViewDiv(' + response[i].aid + ')" style="position: relative; top:126px; left:0px; cursor:pointer; z-index:3" src="images/findhove.png"/>' +
                        '</div>');
                }
            }

            
        }
        
        
        if (response.length > 0) {
            var cats = declOfNum(catnum, ['КОТА', 'КОТА', 'КОТОВ']);
            $("#CatCount").html('УЖЕ ВЗЯЛИ <span class="BlueText">' + catnum + '</span> ' + cats);
        }
       
        if (!PagerInited) {
            InitPager(TotalItems);
        } else {
            var totp = TotalItems / 9 + 1;
            if (TotalItems % 9 == 0) {
                totp = TotalItems / 9;
            }

            $('#PagerChild').bootstrapPaginator({ totalPages: totp });
        }
    });
}

function InitPager(total) {

    var totpages = total / 9 + 1;
    if (total % 9 == 0) {
        totpages = total / 9;
    }
    $('#PagerChild').bootstrapPaginator({
        totalPages: totpages,
        currentPage: 1,
        onPageClicked: function (e, originalEvent, type, page) {
            
            var totp = TotalItems / 9 + 1;
            if (TotalItems % 9 == 0) {
                totp = TotalItems / 9;
            }

            $(this).bootstrapPaginator({
                totalPages: totp
            });
            getpage(page);
        }
    });

    PagerInited = true;
}


function saveAdvert(uid, sessid, phone, email, city, descr, closed, deleted) {
   
    if (!AdvertReady) {
        return;
    }

    if (AdvertId == undefined) {
        $.post("ajax.ashx", { m: "saveadvert", uid: uid, sessid: sessid, phone: phone, email: email, city: city, descr: descr, photos: Images }, function(r) {
            var response = $.parseJSON(r);
            if (response.result == true) {
                CloseAddDiv();
                getpage(CurrentPage);
            }
        });
    } else {
        $.post("ajax.ashx", { m: "updateadvert", aid: AdvertId, uid: uid, sessid: sessid, phone: phone, email: email, city: city, descr: descr, photos: Images, closed: CurrentClosed, deleted: false }, function (r) {
            var response = $.parseJSON(r);
            if (response.result == true) {
                CloseAddDiv();
                getpage(CurrentPage);
            }
        });
    }
    ga('send', 'event', 'create', 'SaveAdvertising');
}

function CheckAdvertReady() {
    if (Images != "" && uid != undefined && sessid != undefined && $('#txtPhone').val() != "" && $('#txtEmail').val() != "" && $('#txtCity').val() != "" && $('#txtDescription').val()) {
        AdvertReady = true;
        SetButtonEnabled(true, "#ReadyCatButton", "btnReady");
    } else {
        AdvertReady = false;
    }
}