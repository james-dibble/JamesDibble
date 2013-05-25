// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStoredProcedureMapper.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Data.Persistence.StoredProcedureMapping
{
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Implementing classes define methods for mapping SQL Stored Procedures
    /// to <see cref="IPersistedObject"/>s
    /// </summary>
    /// <typeparam name="T">
    /// The type of <see cref="IPersistedObject"/> this <see cref="IStoredProcedureMapper{T}"/> maps.
    /// </typeparam>
    public interface IStoredProcedureMapper<T> : IStoredProcedureMapper where T : class, IPersistedObject
    {
        /// <summary>
        /// Extract a domain object from the given <see cref="IDataReader"/>.
        /// </summary>
        /// <param name="reader">
        /// The executed <see cref="IDataReader"/>.
        /// </param>
        /// <returns>
        /// The populated <see cref="IPersistedObject"/>.
        /// </returns>
        T PopulateObject(IDataReader reader);

        /// <summary>
        /// Get an <see cref="IDbCommand"/> to select a single object matching the 
        /// given <paramref name="searchCriteria"/>.
        /// </summary>
        /// <param name="searchCriteria">Values to populate the select parameters.</param>
        /// <returns>A command to execute.</returns>
        IDbCommand GetSelectCommand(IPersistenceSearcher<T> searchCriteria);

        /// <summary>
        /// Get an <see cref="IDbCommand"/> to select a collection of the object matching the 
        /// given <paramref name="searchCriteria"/>.
        /// </summary>
        /// <param name="searchCriteria">Values to populate the select parameters.</param>
        /// <returns>A command to execute.</returns>
        IDbCommand GetSelectCommand(IPersistenceCollectionSearcher<T> searchCriteria);

        /// <summary>
        /// Get a <see cref="IDbCommand"/> that will insert a given object.
        /// </summary>
        /// <param name="newObject">
        /// The object to insert.
        /// </param>
        /// <returns>
        /// A <see cref="IDbCommand"/> to insert this given object;
        /// </returns>
        IDbCommand GetInsertCommand(T newObject);

        /// <summary>
        /// Get a <see cref="IDbCommand"/> that will update a given object.
        /// </summary>
        /// <param name="objectToUpdate">
        /// The object to update.
        /// </param>
        /// <returns>
        /// A <see cref="IDbCommand"/> to update this given object;
        /// </returns>
        IDbCommand GetUpdateCommand(T objectToUpdate);

        /// <summary>
        /// Get a <see cref="IDbCommand"/> that will delete a given object.
        /// </summary>
        /// <param name="objectToDelete">
        /// The object to delete.
        /// </param>
        /// <returns>
        /// A <see cref="IDbCommand"/> to delete this given object;
        /// </returns>
        IDbCommand GetDeleteCommand(T objectToDelete);
    }

    /// <summary>
    /// Do not realise this interface.  Use <see cref="IStoredProcedureMapper{T}"/>.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces",
        Justification = "This is is a non generic interface to be used in dictionary type arguments.")]
    public interface IStoredProcedureMapper
    {
    }
}