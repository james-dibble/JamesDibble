// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessage.cs" company="James Dibble">
//   Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace JamesDibble.ServiceBus.Queueing
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Implementing classes define messages that can be placed upon the service bus.
    /// </summary>
    public interface IMessage : ISerializable
    {
        /// <summary>
        /// Gets the serialised values to be put in the queue.
        /// </summary>
        string Content { get; }
    }
}
