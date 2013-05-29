// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceBusStaticConfigurationManager.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ServiceBus.Configuration.Static
{
    using System;
    using System.Configuration;

    /// <summary>
    /// The service bus configuration manager.
    /// </summary>
    public class ServiceBusStaticConfigurationManager : IServiceBusStaticConfiguration
    {
        private readonly ServiceBusConfigurationSection _configuration;

        /// <summary>
        /// Initialises a new instance of the <see cref="ServiceBusStaticConfigurationManager"/> class.
        /// </summary>
        public ServiceBusStaticConfigurationManager()
        {
            this._configuration =
                ConfigurationManager.GetSection("ServiceBusConfiguration") as ServiceBusConfigurationSection;
        }

        /// <summary>
        /// Gets the default amount of time a message should wait upon the bus.
        /// </summary>
        public TimeSpan DefaultTimeout
        {
            get
            {
                return this._configuration.DefaultTimeout;
            }
        }
    }
}