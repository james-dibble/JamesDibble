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
            var dictionary = new MapperDictionary();
            dictionary.Add<FakeObject, IStoredProcedureMapper<FakeObject>>();
        }

        /// <summary>
        /// The fake object.
        /// </summary>
        public class FakeObject : IPersistedObject
        {
        }
    }
}