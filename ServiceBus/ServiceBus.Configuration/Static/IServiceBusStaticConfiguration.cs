// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceBusStaticConfiguration.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ServiceBus.Configuration.Static
{
    using System;

    /// <summary>
    /// Implementing classes define properties for service bus configuration;
    /// </summary>
    public interface IServiceBusStaticConfiguration
    {
        /// <summary>
        /// Gets the default amount of time a message should wait upon the bus.
        /// </summary>
        TimeSpan DefaultTimeout { get; }
    }
}