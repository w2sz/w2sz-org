// JavaScript for LeftBanner component
function fix_left_banner_pos() {
    //
    // Fix positioning of the left banner content
    //

    // Check if content extends past page
    //     True when body div height > (document height - navibar height)
    // If so, disable absolute positioning of footer and let the browser push it to the bottom
    var navibar = document.getElementById("navbar");
    var left_banner = document.getElementById("left_banner_content_lower");
    if (document.body.offsetHeight > (window.innerHeight - navibar.offsetHeight)) {
        left_banner.style.position = "static";
        left_banner.style.paddingLeft = "0";
    }
    // This function goes both ways so it should set it back otherwise
    else {
        left_banner.style.position = "absolute";
        left_banner.style.paddingLeft = "39.5px";
    }

    // At a certain height, make the solar data panel disappear
    if (window.innerHeight <= 860) {
        document.getElementById("solar_data").style.display = "none";
    }
    else {
        document.getElementById("solar_data").style.display = "block";
    }
}

window.onload = function () {
    fix_left_banner_pos();
};

window.onresize = function () {
    fix_left_banner_pos();
};