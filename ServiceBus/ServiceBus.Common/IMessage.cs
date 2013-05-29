// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessage.cs" company="James Dibble">
//   Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace JamesDibble.ServiceBus
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    /// <summary>
    /// Implementing classes define messages that can be placed upon the service bus.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces",
        Justification = "Marker interface may expand very soon.")]
    public interface IMessage : ISerializable
    {
    }
}
