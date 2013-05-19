// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMapperDictionary.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Data.Persistence.StoredProcedureMapping
{
    /// <summary>
    /// Implementing classes expose methods to map <see cref="IStoredProcedureMapper{T}"/> 
    /// to the <see cref="IPersistedObject"/>s they map.
    /// </summary>
    public interface IMapperDictionary
    {
        /// <summary>
        /// Add a <see cref="IStoredProcedureMapper{T}"/> mapping.
        /// </summary>
        /// <typeparam name="T">
        /// The type this <see cref="IStoredProcedureMapper{T}"/> maps.
        /// </typeparam>
        /// <param name="mapperForType">
        /// The <see cref="IStoredProcedureMapper{T}"/> for the given <typeparamref name="T"/>.
        /// </param>
        void Add<T>(IStoredProcedureMapper<T> mapperForType) where T : class, IPersistedObject;

        /// <summary>
        /// Find a <see cref="IStoredProcedureMapper{T}"/> for this given <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the mapper being requested.
        /// </typeparam>
        /// <returns>
        /// The <see cref="IStoredProcedureMapper{T}"/> for this given <typeparamref name="T"/>.
        /// </returns>
        IStoredProcedureMapper<T> GetMapperForType<T>() where T : class, IPersistedObject; 
    }
}