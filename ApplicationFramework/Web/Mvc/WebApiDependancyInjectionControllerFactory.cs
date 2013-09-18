// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebApiDependancyInjectionControllerFactory.cs" company="James Dibble">
//   Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace JamesDibble.ApplicationFramework.Web.Mvc
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http.Dependencies;

    using JamesDibble.ApplicationFramework.Composition;

    using Microsoft.Practices.Unity.Utility;

    /// <summary>
    /// The dependency injection web API controller factory.
    /// </summary>
    public class WebApiDependancyInjectionControllerFactory : IDependencyResolver
    {
        private readonly IContainer _container;

        /// <summary>
        /// Initialises a new instance of the <see cref="WebApiDependancyInjectionControllerFactory"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public WebApiDependancyInjectionControllerFactory(IContainer container)
        {
            Guard.ArgumentNotNull(container, @"container");

            this._container = container;
        }

        /// <summary>
        /// Retrieves a service from the scope.
        /// </summary>
        /// <returns>
        /// The retrieved service.
        /// </returns>
        /// <param name="serviceType">The service to be retrieved.</param>
        public object GetService(Type serviceType)
        {
            if (this._container.IsRegistered(serviceType))
            {
                return this._container.Resolve(serviceType);
            }
            
            return null;
        }

        /// <summary>
        /// Retrieves a collection of services from the scope.
        /// </summary>
        /// <returns>
        /// The retrieved collection of services.
        /// </returns>
        /// <param name="serviceType">The collection of services to be retrieved.</param>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (this._container.IsRegistered(serviceType))
            {
                return this._container.ResolveAll(serviceType);
            }
            
            return new List<object>();
        }

        /// <summary>
        /// Starts a resolution scope. 
        /// </summary>
        /// <returns>
        /// The dependency scope.
        /// </returns>
        public IDependencyScope BeginScope()
        {
            return new WebApiDependancyInjectionControllerFactory(this._container.CreateChildContainer());
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._container.Dispose();

                GC.SuppressFinalize(this);
            }
        }
    }
}
