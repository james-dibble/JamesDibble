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
    }
}