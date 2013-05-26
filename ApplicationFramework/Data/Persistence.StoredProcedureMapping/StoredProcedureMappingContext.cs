﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StoredProcedureMappingContext.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Data.Persistence.StoredProcedureMapping
{
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// A manager for persistence sources interacted with, with Stored Procedures.
    /// </summary>
    public sealed class StoredProcedureMappingContext : IStoredProcedureMappingContext
    {
        private readonly IMapperDictionary _mappers;
        private readonly IList<IDbCommand> _commandsToCommit;

        /// <summary>
        /// Initialises a new instance of the <see cref="StoredProcedureMappingContext"/> class.
        /// </summary>
        /// <param name="mappers">
        /// A list of the <see cref="IStoredProcedureMapper{T}"/>s that have been configured for this application.
        /// </param>
        public StoredProcedureMappingContext(IMapperDictionary mappers)
        {
            this._commandsToCommit = new List<IDbCommand>();
            this._mappers = mappers;
        }

        /// <summary>
        /// Find an <see cref="IPersistedObject"/>
        /// </summary>
        /// <param name="searchCriteria">
        /// An object defining how to find the <typeparamref name="T"/>.
        /// </param>
        /// <typeparam name="T">
        /// The type of <see cref="IPersistedObject"/>.
        /// </typeparam>
        /// <returns>
        /// An <see cref="IPersistedObject"/> retrieved from the persistence source.
        /// </returns>
        public T Find<T>(IPersistenceSearcher<T> searchCriteria) where T : class, IPersistedObject
        {
            var mapper = this._mappers.GetMapperForType<T>();

            var reader = mapper.GetSelectCommand(searchCriteria).ExecuteReader(CommandBehavior.SingleRow);

            T populatedObject;

            using (reader)
            {
                reader.Read();

                populatedObject = mapper.PopulateObject(reader);
            }

            return populatedObject;
        }

        /// <summary>
        /// Find a collection of <see cref="IPersistedObject"/>
        /// </summary>
        /// <param name="searchCriteria">
        /// An object defining how to find the collection of <typeparamref name="T"/>.
        /// </param>
        /// <typeparam name="T">
        /// The type of <see cref="IPersistedObject"/>.
        /// </typeparam>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of <see cref="IPersistedObject"/> retrieved from the persistence source.
        /// </returns>
        public IEnumerable<T> Find<T>(IPersistenceCollectionSearcher<T> searchCriteria) where T : class, IPersistedObject
        {
            var mapper = this._mappers.GetMapperForType<T>();
            var collection = new List<T>();

            var reader = mapper.GetSelectCommand(searchCriteria).ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    collection.Add(mapper.PopulateObject(reader));
                }
            }

            return collection;
        }

        /// <summary>
        /// Update an object that already exists in the persistence source.
        /// </summary>
        /// <param name="updatedObject">
        /// The object that has changed.
        /// </param>
        /// <typeparam name="T">
        /// The type of <see cref="IPersistedObject"/>.
        /// </typeparam>
        public void Change<T>(T updatedObject) where T : class, IPersistedObject
        {
            var command = this._mappers.GetMapperForType<T>().GetUpdateCommand(updatedObject);

            this._commandsToCommit.Add(command);
        }

        /// <summary>
        /// Insert a new object into the persistence source.
        /// </summary>
        /// <param name="newObject">
        /// The new object.
        /// </param>
        /// <typeparam name="T">
        /// The type of <see cref="IPersistedObject"/>.
        /// </typeparam>
        public void Add<T>(T newObject) where T : class, IPersistedObject
        {
            var command = this._mappers.GetMapperForType<T>().GetInsertCommand(newObject);

            this._commandsToCommit.Add(command);
        }

        /// <summary>
        /// Delete an object from the persistence source.
        /// </summary>
        /// <param name="objectToRemove">
        /// The object to remove.
        /// </param>
        /// <typeparam name="T">
        /// The type of <see cref="IPersistedObject"/>.
        /// </typeparam>
        public void Remove<T>(T objectToRemove) where T : class, IPersistedObject
        {
            var command = this._mappers.GetMapperForType<T>().GetDeleteCommand(objectToRemove);

            this._commandsToCommit.Add(command);
        }

        /// <summary>
        /// Create an instance of <typeparamref name="T"/> and add it to the object graph if applicable.
        /// </summary>
        /// <typeparam name="T">
        /// The type of <see cref="IPersistedObject"/>.
        /// </typeparam>
        /// <returns>
        /// The new instance of <typeparamref name="T"/>.
        /// </returns>
        public T Create<T>() where T : class, IPersistedObject
        {
            return null;
        }

        /// <summary>
        /// Save changes that have been added to the <see cref="IPersistenceManager"/>.
        /// </summary>
        public void Commit()
        {
            foreach (var command in this._commandsToCommit)
            {
                command.ExecuteNonQuery();
            }
        }
    }
}