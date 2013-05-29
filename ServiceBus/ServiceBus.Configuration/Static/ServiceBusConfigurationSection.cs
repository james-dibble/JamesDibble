// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceBusConfigurationSection.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ServiceBus.Configuration.Static
{
    using System;
    using System.Configuration;

    /// <summary>
    /// The service bus configuration section.
    /// </summary>
    public class ServiceBusConfigurationSection : ConfigurationSection
    {
        /// <summary>
        /// Gets the default timeout.
        /// </summary>
        [ConfigurationProperty("defaultTimeout", IsRequired = true)]
        public TimeSpan DefaultTimeout
        {
            get
            {
                return (TimeSpan)this["defaultTimeout"];
            }
        }
    }
}