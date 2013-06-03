// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeMappingDictionary.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Data.Persistence.TypeMapping
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The type mapping dictionary.
    /// </summary>
    [Serializable]
    public class TypeMappingDictionary : Dictionary<Type, Type>, ITypeMappingDictionary
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="TypeMappingDictionary"/> class.
        /// </summary>
        public TypeMappingDictionary()
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="TypeMappingDictionary"/> class.
        /// </summary>
        /// <param name="info">
        /// The info.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        protected TypeMappingDictionary(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Configure a type mapping.
        /// </summary>
        /// <typeparam name="TInterface">
        /// The type of interface that the <typeparamref name="TConcrete" /> is implemented from.
        /// </typeparam>
        /// <typeparam name="TConcrete">
        /// The type <see cref="TInterface"/> maps too.
        /// </typeparam>
        public void Add<TInterface, TConcrete>() where TInterface : class, IPersistedObject where TConcrete : class, TInterface
        {
            this.Add(typeof(TInterface), typeof(TConcrete));
        }
    }
}