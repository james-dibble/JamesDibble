// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExtendedWebViewPageTests.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.UnitTesting.Extensions.MvcTests
{
    using JamesDibble.Extensions.Mvc;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for the <see cref="ExtendedWebViewPage{T}"/> class.
    /// </summary>
    [TestClass]
    public class ExtendedWebViewPageTests
    {
        /// <summary>
        /// Test for the Resource Method.
        /// </summary>
        /// <remarks>TODO: Must eventually look at the application configuration once developed.</remarks>
        [TestMethod]
        public void TestResource()
        {
            const string resourceKey = "image";
            var configuratedResourcePath = string.Empty;
            
            const string resourcePath = "/pictures/thing.png";

            var expected = string.Concat(configuratedResourcePath, resourcePath);

            var actual = new FakeChildClass().Resource(resourceKey, resourcePath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The test get title.
        /// </summary>
        [TestMethod]
        public void TestGetTitle()
        {
            const string expected = "Title";

            var fake = new FakeChildClass { Title = expected };

            var actual = fake.Title;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The test set title.
        /// </summary>
        /// <remarks>TODO: Must eventually look at the application configuration once developed.</remarks>
        [TestMethod]
        public void TestSetTitle()
        {
            var configuredBaseTitle = string.Empty;

            const string testTitle = "Title";

            var expected = string.Concat(configuredBaseTitle, testTitle);

            var fake = new FakeChildClass { Title = testTitle };

            Assert.AreEqual(expected, fake.Title);
        }

        private class FakeChildClass : ExtendedWebViewPage<string>
        {
            /// <summary>
            /// Executes the server code in the current web page that is marked using Razor syntax.
            /// </summary>
            public override void Execute()
            {
            }
        }
    }
}