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

    using QueueingTests.Common;

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

            queueManager.Setup(@".\Private$\TestMessageDtoQueue").Push(message, new TimeSpan(0, 0, 10));
        }
    }
}
