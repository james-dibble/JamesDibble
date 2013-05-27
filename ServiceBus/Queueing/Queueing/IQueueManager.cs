// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQueueManager.cs" company="James Dibble">
//   Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace JamesDibble.ServiceBus.Queueing
{
    using System;

    using JamesDibble.ServiceBus.Configuration;

    /// <summary>
    /// Implementing classes wrap management of service bus queues.
    /// </summary>
    public interface IQueueManager
    {
        /// <summary>
        /// Gets the configuration values as they are in the defined in the executing applications config file.
        /// </summary>
        IServiceBusConfiguration StaticConfiguration { get; }

        /// <summary>
        /// Create a new queue with the given <paramref name="name"/>.
        /// </summary>
        /// <param name="name">
        /// The name of the queue.
        /// </param>
        /// <returns>
        /// The <see cref="IQueueManager"/>.
        /// </returns>
        IQueueManager Setup(string name);

        /// <summary>
        /// Put the given <see cref="IMessage"/> on the queue for processing.
        /// </summary>
        /// <param name="message">The message to add to the queue.</param>
        void Push(IMessage message);

        /// <summary>
        /// Put the given <see cref="IMessage"/> on the queue for processing.
        /// </summary>
        /// <param name="message">The message to add to the queue.</param>
        /// <param name="timeout">How long this message should be kept before going stale.</param>
        void Push(IMessage message, TimeSpan timeout);

        /// <summary>
        /// Dequeue an <see cref="IMessage"/> waiting the default amount of time for a message.
        /// </summary>
        /// <typeparam name="T">
        /// The type of <see cref="IMessage"/> to receive.
        /// </typeparam>
        /// <returns>
        /// The top message in the queue.
        /// </returns>
        T Pop<T>() where T : class, IMessage;

        /// <summary>
        /// Dequeue an <see cref="IMessage"/> with a specified timeout period.
        /// </summary>
        /// <param name="timeout">
        /// How long to wait for a message.
        /// </param>
        /// <typeparam name="T">
        /// The type of <see cref="IMessage"/> to receive.
        /// </typeparam>
        /// <returns>
        /// The top message in the queue.
        /// </returns>
        T Pop<T>(TimeSpan timeout) where T : class, IMessage;
    }
}
