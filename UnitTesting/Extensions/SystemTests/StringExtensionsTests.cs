// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensionsTests.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.UnitTesting.Extensions.System
{
    using global::System;

    using global::System.Collections.Generic;

    using global::System.Diagnostics.CodeAnalysis;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The string extensions tests.
    /// </summary>
    [TestClass]
    public class StringExtensionsTests
    {
        /// <summary>
        /// The test to url string.
        /// </summary>
        [TestMethod]
        public void TestToUrlString()
        {
            const string input = @"hello im testing this";
            const string expected = @"hello-im-testing-this";

            var actual = input.ToUrlString();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The test from url string.
        /// </summary>
        [TestMethod]
        public void TestFromUrlString()
        {
            const string expected = @"hello im testing this";
            const string input = @"hello-im-testing-this";

            var actual = input.FromUrlString();

            Assert.AreEqual(expected, actual);
        }

        #region Pluralise

        /// <summary>
        /// Test pluralise with null collection.
        /// </summary>
        [TestMethod]
        public void TestPluraliseWithNullCollection()
        {
            IEnumerable<string> fakeCollection = null;

            const string input = "random";
            const string expected = "randoms";

            var actual = input.Pluralise(fakeCollection);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test pluralise with populated collection.
        /// </summary>
        [TestMethod]
        public void TestPluraliseWithPopulatedCollection()
        {
            IEnumerable<string> fakeCollection = new List<string>() { "Yo", "YoYo", "YoYoYo" };

            const string input = "random";
            const string expected = "randoms";

            var actual = input.Pluralise(fakeCollection);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The test pluralise no need to pluralise.
        /// </summary>
        [TestMethod]
        public void TestPluraliseNoNeedToPluralise()
        {
            const string expected = @"something";

            var actual = expected.Pluralise(1);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The test pluralise.
        /// </summary>
        [TestMethod]
        public void TestPluraliseExpectS()
        {
            const string input = @"something";

            const string expected = @"somethings";

            var actual = input.Pluralise(3);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The test pluralise.
        /// </summary>
        [TestMethod]
        public void TestPluraliseExpectIes()
        {
            const string input = @"somethingy";

            const string expected = @"somethingies";

            var actual = input.Pluralise(3);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The test pluralise.
        /// </summary>
        [TestMethod]
        public void TestPluraliseExpectOes()
        {
            const string input = @"potato";

            const string expected = @"potatoes";

            var actual = input.Pluralise(3);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        /// <summary>
        /// The test normalize new lines.
        /// </summary>
        [TestMethod]
        public void TestNormalizeNewLines()
        {
            const string input = @"\n\r\n\n";

            var expected = string.Concat(Environment.NewLine, Environment.NewLine, Environment.NewLine, Environment.NewLine);

            var actual = input.NormalizeNewLines();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The test compute hash.
        /// </summary>
        [TestMethod]
        public void TestComputeHash()
        {
            const string input = @"password?";

            var actual = input.ComputeHash();

            Assert.AreNotEqual(input, actual);
        }

        /// <summary>
        /// The test compute hash with salt.
        /// </summary>
        [TestMethod]
        public void TestComputeHashWithSalt()
        {
            const string input = @"password?";
            const string salt = @"salt";

            var actual = input.ComputeHash(salt);

            Assert.AreNotEqual(input, actual);
        }
    }
}