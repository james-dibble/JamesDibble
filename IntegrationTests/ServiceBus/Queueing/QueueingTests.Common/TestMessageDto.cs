// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestMessageDto.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace QueueingTests.Common
{
    using System;
    using System.Runtime.Serialization;
    using JamesDibble.ServiceBus;

    /// <summary>
    /// The test message DTO.
    /// </summary>
    [Serializable]
    public class TestMessageDto : IMessage
    {
        /// <summary>
        /// Gets or sets the random property.
        /// </summary>
        public string RandomProperty { get; set; }

        /// <summary>
        /// Gets or sets the random integer property.
        /// </summary>
        public int RandomIntegerProperty { get; set; }

        /// <summary>
        /// Gets or sets the random double property.
        /// </summary>
        public double RandomDoubleProperty { get; set; }

        /// <summary>
        /// Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo"/> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> to populate with data. </param><param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext"/>) for this serialization. </param><exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
    }
}