// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQueue.cs" company="James Dibble">
//   Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace JamesDibble.ServiceBus.Queueing
{
    /// <summary>
    /// Implementing classes wrap management of service bus queues.
    /// </summary>
    public interface IQueue
    {
        /// <summary>
        /// Create a new queue with the given <paramref name="name"/>.
        /// </summary>
        /// <param name="name">
        /// The name of the queue.
        /// </param>
        /// <returns>
        /// The <see cref="IQueue"/>.
        /// </returns>
        IQueue Setup(string name);

        /// <summary>
        /// Put the given <see cref="IMessage"/> on the queue for processing.
        /// </summary>
        /// <param name="message">The message to add to the queue.</param>
        void Send(IMessage message);

        /// <summary>
        /// Dequeue an <see cref="IMessage"/>.
        /// </summary>
        /// <returns>The top message in the queue.</returns>
        IMessage Recieve();
    }
}
