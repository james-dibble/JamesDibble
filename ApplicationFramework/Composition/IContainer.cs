// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContainer.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Composition
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implementing classes define methods for abstracting IOC containers.
    /// </summary>
    public interface IContainer
    {
        /// <summary>
        /// Setup type mappings and object lifetime policies.
        /// </summary>
        void Configure();

        /// <summary>
        /// Retrieve an instance of <typeparamref name="T"/> as defined in the IOC Container.
        /// </summary>
        /// <typeparam name="T">
        /// The type to retrieve.
        /// </typeparam>
        /// <returns>
        /// A <typeparamref name="T"/> from the <see cref="IContainer"/>.
        /// </returns>
        T Resolve<T>();

        /// <summary>
        /// Retrieve an instance of <typeparamref name="T"/> as defined in the IOC Container.
        /// </summary>
        /// <param name="reference">
        /// The named reference of this <typeparamref name="T"/>.
        /// </param>
        /// <typeparam name="T">
        /// The type to retrieve.
        /// </typeparam>
        /// <returns>
        /// A <typeparamref name="T"/> from the <see cref="IContainer"/>.
        /// </returns>
        T Resolve<T>(string reference);

        /// <summary>
        /// The resolve all.
        /// </summary>
        /// <typeparam name="T">
        /// The type to retrieve.
        /// </typeparam>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        IEnumerable<T> ResolveAll<T>();

        /// <summary>
        /// Retrieve an instance of type as defined in the IOC Container.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// A type from the <see cref="IContainer"/>.
        /// </returns>
        object Resolve(Type type);

        /// <summary>
        /// Retrieve an instance of type as defined in the IOC Container.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="reference">
        /// The named reference of this type.
        /// </param>
        /// <returns>
        /// A type from the <see cref="IContainer"/>.
        /// </returns>
        object Resolve(Type type, string reference);

        /// <summary>
        /// The resolve all.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        IEnumerable<object> ResolveAll(Type type);

        /// <summary>
        /// The is registered.
        /// </summary>
        /// <typeparam name="T">
        /// The type to check for.
        /// </typeparam>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool IsRegistered<T>();

        /// <summary>
        /// The is registered.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool IsRegistered(Type type);

        /// <summary>
        /// The create child container.
        /// </summary>
        /// <returns>
        /// The <see cref="IContainer"/>.
        /// </returns>
        IContainer CreateChildContainer();

        /// <summary>
        /// Dispose of this <see cref="IContainer"/>.
        /// </summary>
        void Dispose();
    }
}