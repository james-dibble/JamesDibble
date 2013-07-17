// --------------------------------------------------------------------------------------------------------------------
// <copyright file="imageLoader.js" company="James Dibble">
//   Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
(function ($) {
    'use strict';

    $.fn.imageLoader = function (options) {

        var defaults = {
            checkLoadedInterval: 200,
            dataAttribute: 'src',
            preload: function () {
            },
            allImagesLoaded: function () {
            },
            imageLoaded: function (image) {
            },
        };
        var imageContainers = $(this);
        var timer = null;
        var imageSources = [];
        var imageQueue = [];

        var checkLoaded = function () {

            var newImageQueue = [];

            $(imageQueue).each(function (index, image) {

                if (image.complete) {
                    var imageSource = unescape(image.src);

                    var matchingContainers = $.grep(imageContainers, function (container) {
                        var dataVal = $(container).data(options.dataAttribute);

                        return dataVal === imageSource;
                    });

                    $(matchingContainers).each(function (containerIndex, container) {

                        if ($(container).is('img')) {
                            $(container).attr('src', imageSource);
                        } else {
                            var url = ['url(\'', imageSource, '\')'].join('');
                            $(container).css({ 'background-image': url });
                        }

                        options.imageLoaded($(container));
                    });
                } else {
                    newImageQueue.push(image);
                }
            });

            imageQueue = newImageQueue;

            if (imageQueue.length === 0) {
                clearInterval(timer);
                options.allImagesLoaded();
                return;
            }
        };

        options = $.extend(defaults, options);

        $(imageContainers).each(function (index, imageElement) {
            var imageSource = $(imageElement).data(options.dataAttribute);

            if (imageSources.indexOf(imageSource) !== -1) {
                return;
            }

            imageSources.push(imageSource);

            var image = new Image();
            image.src = imageSource;
            imageQueue.push(image);
        });

        timer = setInterval(checkLoaded, options.checkLoadedInterval);
    };
})(jQuery);