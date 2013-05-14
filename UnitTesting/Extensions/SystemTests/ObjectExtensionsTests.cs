// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectExtensionsTests.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.UnitTesting.Extensions.System
{
    using global::System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The object extensions tests.
    /// </summary>
    [TestClass]
    public class ObjectExtensionsTests
    {
        /// <summary>
        /// The test copy to.
        /// </summary>
        [TestMethod]
        public void TestCopyTo()
        {
            var input = new TestObject { Property1 = "Hello", Property2 = "Goodbye" };
            var actual = new TestObject { Property1 = "Google", Property2 = "Yahoo" };

            actual = input.CopyTo(actual);

            Assert.AreEqual(input.Property1, actual.Property1);
            Assert.AreEqual(input.Property2, actual.Property2);
        }

        private class TestObject
        {
            public string Property1 { get; set; }

            public string Property2 { get; set; }
        }
    }
}