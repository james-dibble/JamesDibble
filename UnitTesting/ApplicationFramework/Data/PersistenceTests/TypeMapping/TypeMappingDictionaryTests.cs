// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeMappingDictionaryTests.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.UnitTesting.ApplicationFramework.Data.PersistenceTests.TypeMapping
{
    using JamesDibble.ApplicationFramework.Data.Persistence;
    using JamesDibble.ApplicationFramework.Data.Persistence.TypeMapping;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The type mapping dictionary tests.
    /// </summary>
    [TestClass]
    public class TypeMappingDictionaryTests
    {
        private TypeMappingDictionary _target;

        /// <summary>
        /// The FakeObject interface.
        /// </summary>
        public interface IFakeObject : IPersistedObject
        {
        }

        /// <summary>
        /// The test start-up.
        /// </summary>
        [TestInitialize]
        public void TestStartup()
        {
            this._target = new TypeMappingDictionary();
        }

        /// <summary>
        /// The test add.
        /// </summary>
        [TestMethod]
        public void TestAdd()
        {
            var expected = typeof(FakeObject);

            this._target.Add<IFakeObject, FakeObject>();

            Assert.AreEqual(this._target[typeof(IFakeObject)], expected);
        }
        
        /// <summary>
        /// The fake object.
        /// </summary>
        public class FakeObject : IFakeObject
        {
        }
    }
}