// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceBusConfiguration.cs" company="James Dibble">
//   Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace JamesDibble.ServiceBus.Configuration
{
    using JamesDibble.ServiceBus.Configuration.Static;

    /// <summary>
    /// Implementing classes define a the protocol for a service bus.
    /// </summary>
    public interface IServiceBusConfiguration
    {
        /// <summary>
        /// Gets the wrapped values for configuration settings taken from the executing applications
        /// configuration file.
        /// </summary>
        IServiceBusStaticConfiguration StaticConfiguration { get; }
    }
}
