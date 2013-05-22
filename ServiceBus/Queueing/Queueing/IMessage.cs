// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyInfo.cs" company="James Dibble">
//   Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace JamesDibble.ServiceBus.Queueing
{
    /// <summary>
    /// Implementing classes define messages that can be placed upon the service bus.
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// The serialised values to be put in the queue.
        /// </summary>
        string Content { get; }
    }
}
