// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeExtensionsTests.cs" company="James Dibble">
//   Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.UnitTesting.Extensions.System
{
    using global::System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The date time extensions tests.
    /// </summary>
    [TestClass]
    public class DateTimeExtensionsTests
    {
        /// <summary>
        /// The test date ordinal teen.
        /// </summary>
        [TestMethod]
        public void TestDateOrdinalTeen()
        {
            const string expected = "15th";

            var actual = new DateTime(2000, 01, 15).Ordinal();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The test date ordinal eleven.
        /// </summary>
        [TestMethod]
        public void TestDateOrdinalEleven()
        {
            const string expected = "11th";

            var actual = new DateTime(2000, 01, 11).Ordinal();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The test date ordinal first.
        /// </summary>
        [TestMethod]
        public void TestDateOrdinalFirst()
        {
            const string expected = "1st";

            var actual = new DateTime(2000, 01, 01).Ordinal();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The test date ordinal second.
        /// </summary>
        [TestMethod]
        public void TestDateOrdinalSecond()
        {
            const string expected = "2nd";

            var actual = new DateTime(2000, 01, 2).Ordinal();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The test date ordinal third.
        /// </summary>
        [TestMethod]
        public void TestDateOrdinalThird()
        {
            const string expected = "3rd";

            var actual = new DateTime(2000, 01, 3).Ordinal();

            Assert.AreEqual(expected, actual);
        }
    }
}
