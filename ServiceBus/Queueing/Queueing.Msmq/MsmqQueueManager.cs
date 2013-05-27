// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MsmqQueueManager.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ServiceBus.Queueing.Msmq
{
    using System;
    using System.Messaging;

    using JamesDibble.ServiceBus.Configuration;

    /// <summary>
    /// A queue manager for MSMQ transport.
    /// </summary>
    public class MsmqQueueManager : IQueueManager, IDisposable
    {
        private MessageQueue _queue;

        /// <summary>
        /// Initialises a new instance of the <see cref="MsmqQueueManager"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The static configuration for this <see cref="IQueueManager"/>.
        /// </param>
        public MsmqQueueManager(IServiceBusConfiguration configuration)
        {
            this.StaticConfiguration = configuration;
        }

        /// <summary>
        /// Gets the configuration values as they are in the defined in the executing applications config file.
        /// </summary>
        public IServiceBusConfiguration StaticConfiguration { get; private set; }

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
            if (!MsmqInstaller.MsmqIsInstalled)
            {
                MsmqInstaller.ActivateMsmq();
            }

            this._queue = MessageQueue.Exists(name) ? new MessageQueue(name) : MessageQueue.Create(name);

            return this;
        }

        /// <summary>
        /// Put the given <see cref="IMessage"/> on the queue for processing.
        /// </summary>
        /// <param name="message">The message to add to the queue.</param>
        public void Push(IMessage message)
        {
            this.Push(message, this.StaticConfiguration.DefaultTimeout);
        }

        /// <summary>
        /// Put the given <see cref="IMessage"/> on the queue for processing.
        /// </summary>
        /// <param name="message">The message to add to the queue.</param>
        /// <param name="timeout">How long this message should be kept before going stale.</param>
        public void Push(IMessage message, TimeSpan timeout)
        {
            var msmqMessage = new Message(message);

            try
            {
                msmqMessage.TimeToBeReceived = timeout;
                this._queue.Send(msmqMessage);
            }
            finally
            {
                msmqMessage.Dispose();
            }
        }

        /// <summary>
        /// Dequeue an <see cref="IMessage"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The type of <see cref="IMessage"/> to receive.
        /// </typeparam>
        /// <returns>
        /// The top message in the queue.
        /// </returns>
        public T Pop<T>() where T : class, IMessage
        {
            return this.Pop<T>(this.StaticConfiguration.DefaultTimeout);
        }

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
        public T Pop<T>(TimeSpan timeout) where T : class, IMessage
        {
            var message = this._queue.Receive(timeout);

            message.Formatter = new XmlMessageFormatter(new[] { typeof(T) });
            var received = message.Body as T;

            return received;
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