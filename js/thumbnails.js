document.addEventListener("DOMContentLoaded", () => {
    var imgs = [
    "/images/artwork/1JgId04.png",
    "/images/artwork/IMG_1182.jpg",
    "/images/artwork/IMG_2216.jpg",
    "/images/artwork/IMG_2781.JPG",
    "/images/artwork/IMG_4363.jpg",
    "/images/artwork/PXL_20250826_234230909.jpg",
    "/images/artwork/image.png",
    "/images/artwork/DSC00465.JPG",
    "/images/artwork/IMG_1470.jpg",
    "/images/artwork/IMG_2233.jpg",
    "/images/artwork/IMG_2783.JPG",
    "/images/artwork/IMG_5342.jpg",
    "/images/artwork/PXL_20250827_160624593.jpg",
    "/images/artwork/DSC00469.JPG",
    "/images/artwork/IMG_1471.jpg",
    "/images/artwork/IMG_2761.JPG",
    "/images/artwork/IMG_2813-.JPG",
    "/images/artwork/IMG_6283.jpg",
    "/images/artwork/PXL_20250914_152619938.RAW-01.COVER.jpg",
    "/images/artwork/DSC00474.JPG",
    "/images/artwork/IMG_1472.jpg",
    "/images/artwork/IMG_2763.JPG",
    "/images/artwork/IMG_2871.JPG",
    "/images/artwork/IMG_7227.jpg",
    "/images/artwork/PXL_20251004_185224115.jpg",
    "/images/artwork/IMG_1126.JPG",
    "/images/artwork/IMG_1473.jpg",
    "/images/artwork/IMG_2764.JPG",
    "/images/artwork/IMG_3890.jpg",
    "/images/artwork/IMG_7230.jpg",
    "/images/artwork/image0.jpg",
    ];
    var r = Math.floor(imgs.length * Math.random());
    var pic = document.getElementById("profile_image");
    pic.src = imgs[r];
})
