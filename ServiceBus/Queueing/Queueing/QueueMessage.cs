// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueueMessage.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ServiceBus.Queueing
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    using Microsoft.Practices.Unity.Utility;

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
        /// Initialises a new instance of the <see cref="QueueMessage"/> class.
        /// </summary>
        /// <param name="info">
        /// The info.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0",
            Justification = "I is.")]
        protected QueueMessage(SerializationInfo info, StreamingContext context)
        {
            Guard.ArgumentNotNull(info, "info");

            this.Content = info.GetValue("Content", typeof(string)) as string;
        }

        /// <summary>
        /// Gets the serialised values to be put in the queue.
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo"/> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> to populate with data. </param><param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext"/>) for this serialization. </param><exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0",
            Justification = "I is.")]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Guard.ArgumentNotNull(info, "info");

            info.AddValue("Content", this.Content);
        }
    }
}