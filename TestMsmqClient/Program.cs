// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="James Dibble">
//   Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TestMsmqClient
{
    using System;
    using System.Runtime.Serialization;

    using JamesDibble.ServiceBus.Queueing;
    using JamesDibble.ServiceBus.Queueing.Msmq;

    /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The arguments.
        /// </param>
        public static void Main(string[] args)
        {
            var queueManager = new MsmqQueueManager(null);

            var message = new TestMessageDto
                              {
                                  RandomDoubleProperty = 234.45645,
                                  RandomIntegerProperty = 49282,
                                  RandomProperty = @"Yello somebody!"
                              };

            queueManager.Setup(@".\Private$\TestMessageDtoQueue").Push(message, new TimeSpan(1, 0, 0));
        }

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
}
