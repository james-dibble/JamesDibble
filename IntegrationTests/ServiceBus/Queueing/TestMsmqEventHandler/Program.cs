// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="James Dibble">
//   Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TestMsmqEventHandler
{
    using System;

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
        /// <param name="arguments">
        /// The arguments.
        /// </param>
        public static void Main(string[] arguments)
        {
            var queueManager = new MsmqQueueManager(null);

            var recievedMessage = queueManager.Setup(@".\Private$\TestMessageDtoQueue").Pop<TestMessageDto>(new TimeSpan(1, 0, 0));

            Console.Write("{1}{0}{2}{0}{3}", Environment.NewLine, recievedMessage.RandomProperty, recievedMessage.RandomDoubleProperty, recievedMessage.RandomIntegerProperty);

            Console.ReadKey();
        }
    }
}
