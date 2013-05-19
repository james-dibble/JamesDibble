// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapperDictionary.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Data.Persistence.StoredProcedureMapping
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The mapper dictionary.
    /// </summary>
    public class MapperDictionary : IMapperDictionary
    {
        private readonly IDictionary<Type, IStoredProcedureMapper> _internalDictionary;

        /// <summary>
        /// Initialises a new instance of the <see cref="MapperDictionary"/> class.
        /// </summary>
        public MapperDictionary()
        {
            this._internalDictionary = new Dictionary<Type, IStoredProcedureMapper>();
        }

        /// <summary>
        /// Add a <see cref="IStoredProcedureMapper{T}"/> mapping.
        /// </summary>
        /// <typeparam name="T">
        /// Do not The type this <see cref="IStoredProcedureMapper{T}"/> maps.
        /// </typeparam>
        /// <param name="mapperForType">
        /// The <see cref="IStoredProcedureMapper{T}"/> for the given <typeparamref name="T"/>.
        /// </param>
        public void Add<T>(IStoredProcedureMapper<T> mapperForType) where T : class, IPersistedObject
        {
            this._internalDictionary.Add(new KeyValuePair<Type, IStoredProcedureMapper>(typeof(T), mapperForType));
        }

        /// <summary>
        /// Find a <see cref="IStoredProcedureMapper{T}"/> for this given <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the mapper being requested is wrong.
        /// </typeparam>
        /// <returns>
        /// The <see cref="IStoredProcedureMapper{T}"/> for this given <typeparamref name="T"/>.
        /// </returns>
        public IStoredProcedureMapper<T> GetMapperForType<T>() where T : class, IPersistedObject
        {
            return this._internalDictionary[typeof(T)] as IStoredProcedureMapper<T>;
        }
    }
}