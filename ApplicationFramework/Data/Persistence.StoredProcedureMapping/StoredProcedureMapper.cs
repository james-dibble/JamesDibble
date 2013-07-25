// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StoredProcedureMapper.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Data.Persistence.StoredProcedureMapping
{
    using System.Data;

    public abstract class StoredProcedureMapper<T> : IStoredProcedureMapper<T> where T : class, IPersistedObject
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="StoredProcedureMapper{T}"/> class.
        /// </summary>
        protected StoredProcedureMapper(IStoredProcedureMappingContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Gets the <see cref="StoredProcedureMapper{T}"/> this <see cref="IStoredProcedureMapper{T}"/> belongs too.
        /// </summary>
        protected IStoredProcedureMappingContext Context { get; private set; }

        /// <summary>
        /// Extract a domain object from the given <see cref="IDataReader"/>.
        /// </summary>
        /// <param name="reader">
        /// The executed <see cref="IDataReader"/>.
        /// </param>
        /// <returns>
        /// The populated <see cref="IPersistedObject"/>.
        /// </returns>
        public abstract T PopulateObject(IDataReader reader);

        /// <summary>
        /// Get an <see cref="IDbCommand"/> to select a single object matching the 
        /// given <paramref name="searchCriteria"/>.
        /// </summary>
        /// <param name="searchCriteria">Values to populate the select parameters.</param>
        /// <returns>A command to execute.</returns>
        public abstract IDbCommand GetSelectCommand(IPersistenceSearcher<T> searchCriteria);

        /// <summary>
        /// Get an <see cref="IDbCommand"/> to select a collection of the object matching the 
        /// given <paramref name="searchCriteria"/>.
        /// </summary>
        /// <param name="searchCriteria">Values to populate the select parameters.</param>
        /// <returns>A command to execute.</returns>
        public abstract IDbCommand GetSelectCommand(IPersistenceCollectionSearcher<T> searchCriteria);

        /// <summary>
        /// Get a <see cref="IDbCommand"/> that will insert a given object.
        /// </summary>
        /// <param name="newObject">
        /// The object to insert.
        /// </param>
        /// <returns>
        /// A <see cref="IDbCommand"/> to insert this given object;
        /// </returns>
        public abstract IDbCommand GetInsertCommand(T newObject);

        /// <summary>
        /// Get a <see cref="IDbCommand"/> that will update a given object.
        /// </summary>
        /// <param name="objectToUpdate">
        /// The object to update.
        /// </param>
        /// <returns>
        /// A <see cref="IDbCommand"/> to update this given object;
        /// </returns>
        public abstract IDbCommand GetUpdateCommand(T objectToUpdate);

        /// <summary>
        /// Get a <see cref="IDbCommand"/> that will delete a given object.
        /// </summary>
        /// <param name="objectToDelete">
        /// The object to delete.
        /// </param>
        /// <returns>
        /// A <see cref="IDbCommand"/> to delete this given object;
        /// </returns>
        public abstract IDbCommand GetDeleteCommand(T objectToDelete);
    }
}