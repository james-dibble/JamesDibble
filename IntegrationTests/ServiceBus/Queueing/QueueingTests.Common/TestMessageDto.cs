// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestMessageDto.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace QueueingTests.Common
{
    using System;
    using System.Runtime.Serialization;

    using JamesDibble.ServiceBus.Queueing;

    [Serializable]
    public class TestMessageDto : IMessage
    {
        public string RandomProperty { get; set; }

        public int RandomIntegerProperty { get; set; }

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