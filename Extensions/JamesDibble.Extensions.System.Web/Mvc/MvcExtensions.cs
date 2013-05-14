// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MvcExtensions.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace System.Web.Mvc
{
    using System.Globalization;

    /// <summary>
    /// Extensions for MVC
    /// </summary>
    public static class MvcExtensions
    {
        ////private static string _baseTitleString;

        ////private static string BaseTitleString
        ////{
        ////    get
        ////    {
        ////        return _baseTitleString ?? (_baseTitleString = Application.ApplicationConfiguration.BaseTitle.Title);
        ////    }
        ////}

        /////// <summary>
        /////// Get the absolute path for a resource stored in the CDN.
        /////// </summary>
        /////// <param name="helper">
        /////// The helper.
        /////// </param>
        /////// <param name="type">
        /////// The type of this resource.
        /////// </param>
        /////// <param name="resourceLocation">
        /////// The resource location.
        /////// </param>
        /////// <returns>
        /////// The <see cref="string"/>.
        /////// </returns>
        ////public static string Resource<T>(this UrlHelper helper, T type, string resourceLocation) where T : struct
        ////{
        ////    if (resourceLocation.Contains("http://"))
        ////    {
        ////        return resourceLocation;
        ////    }

        ////    var baseLocation = Application.ResourceLocations[type].Path;

        ////    return string.Format(CultureInfo.CurrentCulture, "{0}/{1}", baseLocation, resourceLocation);
        ////}

        /////// <summary>
        /////// The page title.
        /////// </summary>
        /////// <typeparam name="T">
        /////// The view page type.
        /////// </typeparam>
        /////// <param name="page">
        /////// The page.
        /////// </param>
        /////// <param name="title">
        /////// The title.
        /////// </param>
        ////public static void PageTitle<T>(this WebViewPage<T> page, string title)
        ////{
        ////    page.ViewBag.Title = string.Concat(BaseTitleString, title);
        ////}

        /// <summary>
        /// The page description.
        /// </summary>
        /// <typeparam name="T">
        /// The view page type.
        /// </typeparam>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        public static void PageDescription<T>(this WebViewPage<T> page, string description)
        {
            page.ViewBag.Description = description;
        }
    }
}