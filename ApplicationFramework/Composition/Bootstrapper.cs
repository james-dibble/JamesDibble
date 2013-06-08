// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bootstrapper.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Composition
{
    using System;

    /// <summary>
    /// A base class/default <see cref="IBootstrapper"/> implementation for applications to inherit to implement the Bootstrapper pattern.
    /// </summary>
    public abstract class Bootstrapper : IBootstrapper
    {
        /// <summary>
        /// Initialise the <see cref="IBootstrapper"/> and resolve dependencies.
        /// </summary>
        /// <returns>
        /// The <see cref="IContainer"/> configured by this method.
        /// </returns>
        public abstract IContainer Startup();

        /// <summary>
        /// Dispose of the <see cref="IBootstrapper" /> and the objects it manages and end 
        /// the application execution context.
        /// </summary>
        public virtual void Shutdown()
        {
            this.Dispose();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose of any disposable fields of this <see cref="Bootstrapper"/>.
        /// </summary>
        /// <param name="disposing">
        /// A value indicating whether this object is disposing.
        /// </param>
        protected abstract void Dispose(bool disposing);
    }
}