// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMapperDictionary.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Data.Persistence.StoredProcedureMapping
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implementing classes expose methods to map <see cref="IStoredProcedureMapper{T}"/> 
    /// to the <see cref="IPersistedObject"/>s they map.
    /// </summary>
    public interface IMapperDictionary : IDictionary<Type, Type>
    {
        /// <summary>
        /// Add a <see cref="IStoredProcedureMapper{T}"/> mapping.
        /// </summary>
        /// <typeparam name="TMapped">
        /// The type the given <typeparam name="TMapper" /> maps.
        /// </typeparam>
        /// <typeparam name="TMapper">
        /// The <see cref="IStoredProcedureMapper"/> the given <typeparam name="TMapper" /> maps.
        /// </typeparam>
        void Add<TMapped, TMapper>() where TMapped : class, IPersistedObject where TMapper : IStoredProcedureMapper<TMapped>;

        /// <summary>
        /// Find a <see cref="IStoredProcedureMapper{T}"/> for this given <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the mapper being requested.
        /// </typeparam>
        /// <returns>
        /// The <see cref="IStoredProcedureMapper{T}"/> for this given <typeparamref name="T"/>.
        /// </returns>
        Type GetMapperForType<T>() where T : class, IPersistedObject; 
    }
}