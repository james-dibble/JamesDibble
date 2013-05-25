// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MsmqQueueManager.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ServiceBus.Queueing.Msmq
{
    using System;
    using System.Messaging;

    /// <summary>
    /// A queue manager for MSMQ transport.
    /// </summary>
    public class MsmqQueueManager : IQueueManager, IDisposable
    {
        private MessageQueue _queue;

        /// <summary>
        /// Create a new queue with the given <paramref name="name"/>.
        /// </summary>
        /// <param name="name">
        /// The name of the queue.
        /// </param>
        /// <returns>
        /// The <see cref="IQueueManager"/>.
        /// </returns>
        public IQueueManager Setup(string name)
        {
            if (MessageQueue.Exists(name))
            {
                this._queue = new MessageQueue(name);
            }
            else
            {
                this._queue = MessageQueue.Create(name);
            }

            return this;
        }

        /// <summary>
        /// Put the given <see cref="IMessage"/> on the queue for processing.
        /// </summary>
        /// <param name="message">The message to add to the queue.</param>
        public void Send(IMessage message)
        {
            this._queue.Send(message);
        }

        /// <summary>
        /// Dequeue an <see cref="IMessage"/>.
        /// </summary>
        /// <returns>The top message in the queue.</returns>
        public IMessage Receive()
        {
            var recieved = this._queue.Receive();
            recieved.Formatter = new XmlMessageFormatter();

            var message = new QueueMessage(recieved.Body.ToString());

            return message;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose of any disposable fields of this <see cref="MsmqQueueManager"/>.
        /// </summary>
        /// <param name="disposing">
        /// A value indicating whether this object is disposing.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._queue.Dispose();
            }
        }
    }
}