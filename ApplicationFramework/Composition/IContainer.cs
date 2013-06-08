// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContainer.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Composition
{
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
        /// Dispose of this <see cref="IContainer"/>.
        /// </summary>
        void Dispose();
    }
}