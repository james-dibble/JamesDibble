// --------------------------------------------------------------------------------------------------------------------
// <copyright file="imageLoader.js" company="James Dibble">
//   Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

$.fn.imageLoader = function(options) {

    'use strict';

    var defaults = {
        delay: 200,
        dataAttribute: 'src',
        preload: function() {
        },
        allImagesLoaded: function() {
        },
        imageLoaded: function() {
        },
    };

    options = $.extend(defaults, options);

    var imageContainer = $(this),
        images = [imageContainer.length],
        loadedFlags = [imageContainer.length],
        checkTimer = 300,
        timer = null,
        loadImages = function() {

            var loadedImages = 0;

            $(images).each(function(index, image) {
                if (!loadedFlags[index]) {
                    if (image.complete) {
                        loadedImages += 1;

                        loadedFlags[index] = true;

                        var element = $(imageContainer[index]);
                        var source = images[index].src;

                        if (element.is('img')) {
                            element.attr('src', source);
                        } else {
                            var url = ['url(\'', source, '\')'].join('');
                            element.css({ 'background-image': url });
                        }

                        options.imageLoaded(element);
                    }
                } else {
                    loadedImages += 1;
                }
            });

            if (loadedImages >= images.length) {
                allLoaded();
            }
        };

    $(imageContainer).each(function(index, elm) {
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
};