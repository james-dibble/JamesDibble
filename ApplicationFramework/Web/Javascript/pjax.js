// --------------------------------------------------------------------------------------------------------------------
// <copyright file="pjax.js" company="James Dibble">
//   Copyright 2013 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
(function ($) {
    'use strict';

    $.fn.pjax = function (options) {

        var defaults = {
            locationAttribute: 'href',
            pjaxLinkSelector: 'a[data-pjax="true"]',
            analytics: null,
            preLoad: function () {
            },
            postLoad: function () {
            },
            onErrorLoading: function () {
            },
        };

        options = $.extend(defaults, options);

        if (!$.fn.pjax.enabled) {
            $.fn.pjax.enabled = true;
            initPjax();
        }

        var pjaxLinkContainer = $(this);

        $(pjaxLinkContainer).on('click', options.pjaxLinkSelector, function () {
            if (!window.History.enabled) {
                return true;
            }

            var path = $(this).attr(options.locationAttribute),
                id = new Date().getTime();

            if (path != location.href) {
                $.fn.pjax.actionOptions.push({
                    id: id,
                    options: options
                });

                window.History.pushState({ pjax: true, actionOptionsId: id }, document.title, path);
            }

            return false;
        });
    };

    var initPjax = function () {
        window.History.replaceState({ pjax: false }, document.title, location.pathname + location.search);

        window.History.Adapter.bind(window, 'statechange', function () {

            var initialPop = !$.fn.pjax.popped && location.href == $.fn.pjax.initialUrl;
            $.fn.pjax.popped = true;

            if (initialPop) return true;

            var state = window.History.getState();

            if (state && state.data.pjax) {

                var actionOptions = getActionOptions(state.data.actionOptionsId);

                actionOptions.options.preLoad();

                setTimeout(function () {
                    $.ajax({
                        url: location.pathname + location.search,
                        beforeSend: function (xhrObj) {
                            xhrObj.setRequestHeader("X-PJAX", "true");
                        },
                        success: function (data, status, xhr) {
                            if (actionOptions.options.analytics) {
                                actionOptions.options.analytics.push(['_trackPageview']);
                            }

                            var title = xhr.getResponseHeader("X-PJAX-Title");

                            if (title) {
                                document.title = title;
                            }

                            actionOptions.options.onLoad(data, status, xhr);
                        },
                        error: function (jqXhr, textStatus, errorThrown) {
                            actionOptions.options.onErrorLoading(jqXhr, textStatus, errorThrown);
                        }
                    });
                }, 1000);

                return false;
            } else {
                window.location = location.pathname + location.search;
                return true;
            }
        });
    };

    var getActionOptions = function (id) {
        var matches = $.grep($.fn.pjax.actionOptions, function (e) { return e.id == id; });

        return matches[0];
    };

    $.fn.pjax.enabled = false;
    $.fn.pjax.initialUrl = location.href;
    $.fn.pjax.popped = ('state' in window.History);
    $.fn.pjax.actionOptions = [];
})(jQuery);