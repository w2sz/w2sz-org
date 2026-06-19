// JavaScript for Home component

export function loadImage(image) {
    // Add path prefix to image filename
    image = "/Images/CoverImages/" + image;

    var coverImage = document.getElementById("cover_image");

    // Create loader while preloading the image
    var loader = new Image();
    loader.onload = function () {
        // Image is loaded, replace the rotating logo with it
        coverImage.classList.remove("rotating_image");
        coverImage.classList.add("fade_in");
        coverImage.src = image;
    };
    loader.src = image;
}