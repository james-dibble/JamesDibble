$.fn.imageLoader = function (options) {

    var defaults = {
        delay: 200,
        dataAttribute: 'src',
        preload: function () { },
        allImagesLoaded: function () { },
        imageLoaded: function (image) { },
    };

    options = $.extend(defaults, options);

    var imageContainer = $(this),
        images = [imageContainer.length],
        loadedFlags = [imageContainer.length],
        checkTimer = 300,
        timer = null;

    var loadImages = function () {
        var loadedImages = 0;

        for (var loadedImagesCount = 0; loadedImagesCount < images.length; loadedImagesCount++) {
            if (!loadedFlags[loadedImagesCount]) {
                if (images[loadedImagesCount].complete) {
                    loadedImages++;
                    loadedFlags[loadedImagesCount] = true;

                    var element = $(imageContainer[loadedImagesCount]);
                    var source = images[loadedImagesCount].src;

                    if (element.is('img')) {
                        element.attr('src', source);
                    } else {
                        var url = ['url(\'', source, '\')'].join('');
                        element.css({ 'background-image': url });
                    }

                    options.imageLoaded();
                }
            } else {
                loadedImages++;
            }
        }

        if (loadedImages >= images.length) {
            allLoaded();
        }
    };

    $(imageContainer).each(function (index, elm) {
        loadedFlags[index] = false;
        var source = $(elm).data(options.dataAttribute);
        var image = new Image();
        image.src = source;
        images[index] = image;
    });

    timer = setInterval(loadImages, checkTimer);

    function allLoaded() {
        clearInterval(timer);
        options.allImagesLoaded();
        return;
    }
}