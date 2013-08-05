// --------------------------------------------------------------------------------------------------------------------
// <copyright file="scrollToTop.js" company="James Dibble">
//   Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
(function ($) {
    'use strict';

    $.fn.scrollToTop = function (options) {

        var defaults = {
            animate: true,
            animationDuration: 500,
            offest: 0,
            easing: '',
            callback: function () {
            }
        };

        var scrollToTopLinks = $(this);

        options = $.extend(defaults, options);

        $(scrollToTopLinks).click(function () {

            var executeCallback = false;

            var callbackWrapper = function () {
                if (executeCallback) {
                    options.callback();
                }

                executeCallback = !executeCallback;
            };

            var animationOptions = {
                duration: options.animate ? options.animationDuration : 0,
                easing: options.easing,
                complete: callbackWrapper
            };

            $('body,html').animate({
                scrollTop: options.offest
            },
                animationOptions
            );

            return false;
        });
    };
})(jQuery);