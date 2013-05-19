// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StoredProcedureMappingTests.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Persitence.StoredProcedureMappingTests
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    using JamesDibble.ApplicationFramework.Data.Persistence;
    using JamesDibble.ApplicationFramework.Data.Persistence.StoredProcedureMapping;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    /// <summary>
    /// The stored procedure mapping tests.
    /// </summary>
    [TestClass]
    public class StoredProcedureMappingTests
    {
        /// <summary>
        /// The test change.
        /// </summary>
        [TestMethod]
        public void TestChange()
        {
            var mapperDictionary = new MapperDictionary();
            var mapper = new Mock<IStoredProcedureMapper<FakeObject>>();
            var command = new Mock<IDbCommand>();
            var fakeObject = new FakeObject();

            mapper.Setup(m => m.GetUpdateCommand(fakeObject)).Returns(command.Object);
            mapperDictionary.Add(mapper.Object);

            var context = new StoredProcedureMappingContext(mapperDictionary);
            context.Change(fakeObject);
        }

        /// <summary>
        /// The test add.
        /// </summary>
        [TestMethod]
        public void TestAdd()
        {
            var mapperDictionary = new MapperDictionary();
            var mapper = new Mock<IStoredProcedureMapper<FakeObject>>();
            var command = new Mock<IDbCommand>();
            var fakeObject = new FakeObject();

            mapper.Setup(m => m.GetInsertCommand(fakeObject)).Returns(command.Object);
            mapperDictionary.Add(mapper.Object);

            var context = new StoredProcedureMappingContext(mapperDictionary);
            context.Add(fakeObject);
        }

        /// <summary>
        /// The test remove.
        /// </summary>
        [TestMethod]
        public void TestRemove()
        {
            var mapperDictionary = new MapperDictionary();
            var mapper = new Mock<IStoredProcedureMapper<FakeObject>>();
            var command = new Mock<IDbCommand>();
            var fakeObject = new FakeObject();

            mapper.Setup(m => m.GetDeleteCommand(fakeObject)).Returns(command.Object);
            mapperDictionary.Add(mapper.Object);

            var context = new StoredProcedureMappingContext(mapperDictionary);
            context.Remove(fakeObject);
        }

        /// <summary>
        /// The test find single object.
        /// </summary>
        [TestMethod]
        public void TestFindSingleObject()
        {
            var mapperDictionary = new MapperDictionary();
            var fakeSearchCriteria = new Mock<IPersistenceSearcher>();
            var mapper = new Mock<IStoredProcedureMapper<FakeObject>>();
            
            var fakeObject = new FakeObject();
            var fakeReader = new Mock<IDataReader>();
            var readToggle = true;
            fakeReader.Setup(x => x.Read())
                .Returns(() => readToggle)
                .Callback(() => readToggle = false); 

            var command = new Mock<IDbCommand>();
            command.Setup(c => c.ExecuteReader(CommandBehavior.SingleRow)).Returns(fakeReader.Object);

            mapper.Setup(m => m.GetSelectCommand(fakeSearchCriteria.Object)).Returns(command.Object);
            mapper.Setup(m => m.PopulateObject(fakeReader.Object)).Returns(fakeObject);
            mapperDictionary.Add(mapper.Object);

            var actual = new StoredProcedureMappingContext(mapperDictionary).Find<FakeObject>(fakeSearchCriteria.Object);

            Assert.AreEqual(fakeObject, actual);
        }

        /// <summary>
        /// The test find collection.
        /// </summary>
        [TestMethod]
        public void TestFindCollection()
        {
            var mapperDictionary = new MapperDictionary();
            var fakeSearchCriteria = new Mock<IPersistenceCollectionSearcher>();
            var mapper = new Mock<IStoredProcedureMapper<FakeObject>>();
            var fakeCollection = new Queue<FakeObject>();
            var fakeObject1 = new FakeObject();
            var fakeObject2 = new FakeObject();

            fakeCollection.Enqueue(fakeObject1);
            fakeCollection.Enqueue(fakeObject2);

            var fakeReader = new Mock<IDataReader>();
            fakeReader.Setup(r => r.Read())
                .Returns(new Queue<bool>(new[] { true, true, false }).Dequeue);

            var fakeCommand = new Mock<IDbCommand>();
            fakeCommand.Setup(c => c.ExecuteReader()).Returns(fakeReader.Object);

            mapper.Setup(m => m.GetSelectCommand(fakeSearchCriteria.Object)).Returns(fakeCommand.Object);
            mapper.Setup(m => m.PopulateObject(fakeReader.Object)).Returns(fakeCollection.Dequeue);
            
            mapperDictionary.Add(mapper.Object);

            var actual = new StoredProcedureMappingContext(mapperDictionary).Find<FakeObject>(fakeSearchCriteria.Object);

            Assert.AreEqual(fakeObject1, actual.ElementAt(0));
            Assert.AreEqual(fakeObject2, actual.ElementAt(1));
        }

        /// <summary>
        /// The fake object.
        /// </summary>
        public class FakeObject : IPersistedObject
        {
        }
    }
}