// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapperDictionaryTests.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Persitence.StoredProcedureMappingTests
{
    using JamesDibble.ApplicationFramework.Data.Persistence;
    using JamesDibble.ApplicationFramework.Data.Persistence.StoredProcedureMapping;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    /// <summary>
    /// The mapper dictionary tests.
    /// </summary>
    [TestClass]
    public class MapperDictionaryTests
    {
        /// <summary>
        /// The test dictionary.
        /// </summary>
        [TestMethod]
        public void TestDictionary()
        {
            var fakeMapper = new Mock<IStoredProcedureMapper<FakeObject>>();

            var dictionary = new MapperDictionary();
            dictionary.Add<FakeObject>(fakeMapper.Object);

            var actual = dictionary.GetMapperForType<FakeObject>();

            Assert.AreEqual(fakeMapper.Object, actual);
        }

        public class FakeObject : IPersistedObject
        {
        }
    }
}