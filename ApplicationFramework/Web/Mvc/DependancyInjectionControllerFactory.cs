// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DependancyInjectionControllerFactory.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Web.Mvc
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Web.SessionState;
    using JamesDibble.ApplicationFramework.Composition;

    /// <summary>
    /// The dependancy injection controller factory.
    /// </summary>
    public class DependancyInjectionControllerFactory : IControllerFactory
    {
        private readonly IContainer _container;

        /// <summary>
        /// Initialises a new instance of the <see cref="DependancyInjectionControllerFactory"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public DependancyInjectionControllerFactory(IContainer container)
        {
            this._container = container;
        }

        /// <summary>
        /// Creates the specified controller by using the specified request context.
        /// </summary>
        /// <returns>
        /// The controller.
        /// </returns>
        /// <param name="requestContext">The request context.</param><param name="controllerName">The name of the controller.</param>
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            try
            {
                return this._container.Resolve<IController>(controllerName);
            }
            catch
            {
                return new DefaultControllerFactory().CreateController(requestContext, controllerName);
            }
        }

        /// <summary>
        /// Gets the controller's session behavior.
        /// </summary>
        /// <returns>
        /// The controller's session behavior.
        /// </returns>
        /// <param name="requestContext">The request context.</param><param name="controllerName">The name of the controller whose session behavior you want to get.</param>
        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        /// <summary>
        /// Releases the specified controller.
        /// </summary>
        /// <param name="controller">The controller.</param>
        public void ReleaseController(IController controller)
        {
            if (controller is IDisposable)
            {
                var disposable = controller as IDisposable;

                disposable.Dispose();
            }
            else
            {
                controller = null;
            }
        }
    }
}