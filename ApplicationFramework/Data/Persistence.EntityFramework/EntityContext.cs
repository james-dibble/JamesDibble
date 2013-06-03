// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityContext.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Data.Persistence.EntityFramework
{
    using System;
    using System.Data.Entity;

    using JamesDibble.ApplicationFramework.Configuration;
    using JamesDibble.ApplicationFramework.Data.Persistence;

    using Microsoft.Practices.Unity.Utility;

    /// <summary>
    /// A manager for Entity Framework persistence sources.
    /// </summary>
    public sealed class EntityContext : DbContext, IEntityContext
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="EntityContext"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        public EntityContext(IConfigurationManager configuration) : this(ConfigurationManagerGuard(configuration).ConnectionString("default"))
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="EntityContext"/> class.
        /// </summary>
        /// <param name="connectionString">
        /// The connection string to create this <see cref="EntityContext"/> with.
        /// </param>
        public EntityContext(string connectionString) : base(connectionString)
        {
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = false;
        }

        /// <summary>
        /// Retrieve the object set for the type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The <see cref="IPersistedObject"/> to get the set of.
        /// </typeparam>
        /// <returns>
        /// The <see cref="DbSet"/> in the current object graph.
        /// </returns>
        public DbSet<T> GetSet<T>() where T : class, IPersistedObject
        {
            if (typeof(T).IsInterface)
            {
                // TODO?:  Resolve the interface type via IOC?.
                throw new ArgumentException(
                    "Why on earth do think that you can get an entity set of a non concrete type?");
            }

            return this.Set<T>();
        }

        private static IConfigurationManager ConfigurationManagerGuard(IConfigurationManager configuration)
        {
            Guard.ArgumentNotNull(configuration, "configuration");

            return configuration;
        }
    }
}