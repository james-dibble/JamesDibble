// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigurationManagerWrapper.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Configuration
{
    using System.Collections.Specialized;
    using System.Configuration;

    /// <summary>
    /// A wrapper for the <see cref="ConfigurationManager"/> class.
    /// </summary>
    public class ConfigurationManagerWrapper : IConfigurationManager
    {
        /// <summary>
        /// Gets the app settings collection.
        /// </summary>
        public NameValueCollection AppSettings
        {
            get
            {
                return ConfigurationManager.AppSettings;
            }
        }

        /// <summary>
        /// Gets a configured value for the title of a window.
        /// </summary>
        public string BaseTitle 
        {
            get
            {
                var configurationSection = this.GetSection<ApplicationConfigurationSection>("applicationConfiguration");

                return configurationSection.BaseTitle.Title;
            }
        }

        /// <summary>
        /// Get a named connection.
        /// </summary>
        /// <param name="name">
        /// The name of the connection.
        /// </param>
        /// <returns>
        /// A named connection string.
        /// </returns>
        public string ConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        /// <summary>
        /// Get a named configuration section of a given type.
        /// </summary>
        /// <param name="sectionName">
        /// The section name.
        /// </param>
        /// <typeparam name="T">
        /// The <see cref="ConfigurationSection"/> type.
        /// </typeparam>
        /// <returns>
        /// The configuration section of type <typeparamref name="T"/>.
        /// </returns>
        public T GetSection<T>(string sectionName) where T : ConfigurationSection
        {
            var section = ConfigurationManager.GetSection(sectionName) as T;
            
            return section;
        }

        /// <summary>
        /// The resource path.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string ResourcePath(string type)
        {
            var configurationSection = this.GetSection<ApplicationConfigurationSection>("applicationConfiguration").ResourceLocations;

            return string.Concat(configurationSection.BasePath, configurationSection.Resource(type));
        }
    }
}