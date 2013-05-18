// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExtendedWebViewPageTests.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.UnitTesting.Extensions.MvcTests
{
    using JamesDibble.ApplicationFramework.Configuration;
using JamesDibble.Extensions.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Tests for the <see cref="ExtendedWebViewPage{T}"/> class.
    /// </summary>
    [TestClass]
    public class ExtendedWebViewPageTests
    {
        private const string _baseTitle = "Base Title";
        private const string _baseResourcePath = "../'images";

        /// <summary>
        /// Test for the Resource Method.
        /// </summary>
        [TestMethod]
        public void TestResource()
        {
            const string resourceKey = "image";
            var configuratedResourcePath = _baseResourcePath;
            
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
            const string input = "Title";

            var fake = new FakeChildClass { Title = input };

            var expected = string.Concat(_baseTitle, input);

            var actual = fake.Title;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The test set title.
        /// </summary>
        [TestMethod]
        public void TestSetTitle()
        {
            var configuredBaseTitle = _baseTitle;

            const string testTitle = "Title";

            var expected = string.Concat(configuredBaseTitle, testTitle);

            var fake = new FakeChildClass { Title = testTitle };

            Assert.AreEqual(expected, fake.Title);
        }

        private class FakeChildClass : ExtendedWebViewPage<string>
        {
            protected new IConfigurationManager Configuration
            {
                get
                {
                    var fakeConfiguration = new Mock<IConfigurationManager>();

                    fakeConfiguration.Setup(c => c.BaseTitle).Returns(ExtendedWebViewPageTests._baseTitle);
                    fakeConfiguration.Setup(c => c.ResourcePath(It.IsAny<string>())).Returns(ExtendedWebViewPageTests._baseResourcePath);

                    return fakeConfiguration.Object;
                }
            }

            /// <summary>
            /// Executes the server code in the current web page that is marked using Razor syntax.
            /// </summary>
            public override void Execute()
            {
            }
        }
    }
}