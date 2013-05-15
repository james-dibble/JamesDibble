// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MvcExtensionsTests.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.UnitTesting.Extensions.System.Web.Mvc
{
    using global::System.Web.Mvc;

    using Microsoft.VisualStudio.TestTools.UnitTesting;


    /// <summary>
    /// Tests for the <see cref="MvcExtensions"/> class.
    /// </summary>
    [TestClass]
    public class MvcExtensionsTests
    {
        /// <summary>
        /// Test that a value for the page's description is set.
        /// </summary>
        [TestMethod]
        public void TestPageDescription()
        {
            const string fakeDescription = "Yo yo!  This description is bitchin'";

            var webpage = new TestPage();

            webpage.PageDescription(fakeDescription);

            Assert.AreEqual(fakeDescription, webpage.ViewBag.Description);
        }

        private class TestPage : WebViewPage<string>
        {
            public override void Execute()
            {
            }
        }
    }
}