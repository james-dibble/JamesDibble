// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBootstrapper.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Composition
{
    using System;

    /// <summary>
    /// Implementing classes define an object that initialises application components.
    /// </summary>
    public interface IBootstrapper : IDisposable
    {
        /// <summary>
        /// Initialise the <see cref="IBootstrapper"/> and resolve dependencies.
        /// </summary>
        void Startup();

        /// <summary>
        /// Dispose of the <see cref="IBootstrapper" /> and the objects it manages and end 
        /// the application execution context.
        /// </summary>
        void Shutdown();
    }
}