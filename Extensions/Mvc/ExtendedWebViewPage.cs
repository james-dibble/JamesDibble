// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExtendedWebViewPage.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.Extensions.Mvc
{
    using System.IO;
    using System.Web.Mvc;
    using JamesDibble.ApplicationFramework.Configuration;

    /// <summary>
    /// A base class for Razor web pages with some additional properties.
    /// </summary>
    /// <typeparam name="T">The type of the view data model.</typeparam>
    public abstract class ExtendedWebViewPage<T> : WebViewPage<T>
    {
        private string _pageTitle;
        private IConfigurationManager _configuration;

        /// <summary>
        /// Initialises a new instance of the <see cref="ExtendedWebViewPage{T}"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        protected ExtendedWebViewPage(IConfigurationManager configuration)
        {
            this._configuration = configuration;
        }

        /// <summary>
        /// Gets or sets the title of this <see cref="WebViewPage{T}"/>.
        /// </summary>
        public string Title
        {
            get
            {
                return this._pageTitle;
            }

            set
            {
                var baseTitle = this.Configuration.BaseTitle;
                this._pageTitle = string.Concat(baseTitle, value);
            }
        }

        /// <summary>
        /// Gets or sets the description for this <see cref="WebViewPage{T}"/>.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        protected IConfigurationManager Configuration
        {
            get
            {
                return this._configuration;
            }
        }

        /// <summary>
        /// Executes the server code in the current web page that is marked using Razor syntax.
        /// </summary>
        public abstract override void Execute();

        /// <summary>
        /// Create a path for a given <paramref name="resourceTypeKey"/>.
        /// </summary>
        /// <param name="resourceTypeKey">
        /// The type of this resource.
        /// </param>
        /// <param name="resourcePath">
        /// The path of the actual resource.
        /// </param>
        /// <returns>
        /// The path to the resource.
        /// </returns>
        public string Resource(string resourceTypeKey, string resourcePath)
        {
            var resourceTypePath = this.Configuration.ResourcePath(resourceTypeKey);

            var fullPath = string.Concat(resourceTypePath, resourcePath);

            return fullPath;
        }
    }
}