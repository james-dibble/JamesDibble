// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapperDictionary.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Data.Persistence.StoredProcedureMapping
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Runtime.Serialization;

    /// <summary>
    /// The mapper dictionary.
    /// </summary>
    [Serializable]
    public class MapperDictionary : Dictionary<Type, Type>, IMapperDictionary
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="MapperDictionary"/> class.
        /// </summary>
        public MapperDictionary()
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="MapperDictionary"/> class.
        /// </summary>
        /// <param name="info">
        /// The info.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        protected MapperDictionary(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        /// Add a <see cref="IStoredProcedureMapper{T}"/> mapping.
        /// </summary>
        /// <typeparam name="TMapped">
        /// The type the given <typeparam name="TMapper" /> maps.
        /// </typeparam>
        /// <typeparam name="TMapper">
        /// The <see cref="IStoredProcedureMapper"/> the given <typeparam name="TMapper" /> maps.
        /// </typeparam>
        public void Add<TMapped, TMapper>() where TMapped : class, IPersistedObject where TMapper : IStoredProcedureMapper<TMapped>
        {
            this.Add(typeof(TMapped), typeof(TMapper));
        }

        /// <summary>
        /// Find a <see cref="IStoredProcedureMapper{T}"/> for this given <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the mapper being requested.
        /// </typeparam>
        /// <returns>
        /// The <see cref="IStoredProcedureMapper{T}"/> for this given <typeparamref name="T"/>.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the <see cref="MapperDictionary"/> has no mapper defined for the given <typeparamref name="T"/>.
        /// </exception>
        public Type GetMapperForType<T>() where T : class, IPersistedObject
        {
            try
            {
                return this[typeof(T)];
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format(
                        CultureInfo.CurrentCulture, 
                        "The MapperDictionary currently contains no mapper for the type {0}.", 
                        typeof(T).FullName),
                    ex);
            }
        }
    }
}