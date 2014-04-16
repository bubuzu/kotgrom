function declOfNum(number, titles) {
    cases = [2, 0, 1, 1, 1, 2];
    return titles[(number % 100 > 4 && number % 100 < 20) ? 2 : cases[(number % 10 < 5) ? number % 10 : 5]];
}

function SetButtonEnabled(enabled, owner, img) {
    if (enabled) {
        $(owner).css("background-image", "url(images/" + img + ".png)");
        $(owner).css("cursor", "pointer");
    } else {
        $(owner).css("background-image", "url(images/" + img + "_disabled.png)");
        $(owner).css("cursor", "default");
    }
}