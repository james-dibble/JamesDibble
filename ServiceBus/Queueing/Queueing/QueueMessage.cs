// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueueMessage.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ServiceBus.Queueing
{
    using System;

    /// <summary>
    /// A message that can be placed upon the service bus.
    /// </summary>
    [Serializable]
    public class QueueMessage : IMessage
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="QueueMessage"/> class.
        /// </summary>
        /// <param name="content">Serialised information to be placed upon the service bus.</param>
        public QueueMessage(string content)
        {
            this.Content = content;
        }

        /// <summary>
        /// Gets the serialised values to be put in the queue.
        /// </summary>
        public string Content { get; private set; }
    }
}