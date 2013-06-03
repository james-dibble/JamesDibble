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
    using JamesDibble.ApplicationFramework.Data.Persistence.TypeMapping;

    using Microsoft.Practices.Unity.Utility;

    /// <summary>
    /// A manager for Entity Framework persistence sources.
    /// </summary>
    public sealed class EntityContext : DbContext, IEntityContext
    {
        private readonly ITypeMappingDictionary _typeMapping;

        /// <summary>
        /// Initialises a new instance of the <see cref="EntityContext"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        /// <param name="typeMapping">
        /// Inject interface type mappings into the persistence source.
        /// </param>
        public EntityContext(IConfigurationManager configuration, ITypeMappingDictionary typeMapping)
            : this(ConfigurationManagerGuard(configuration).ConnectionString("default"), typeMapping)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="EntityContext"/> class.
        /// </summary>
        /// <param name="connectionString">
        /// The connection string to create this <see cref="EntityContext"/> with.
        /// </param>
        /// <param name="typeMapping">
        /// Inject interface type mappings into the persistence source.
        /// </param>
        public EntityContext(string connectionString, ITypeMappingDictionary typeMapping) : base(connectionString)
        {
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = false;
            this._typeMapping = typeMapping;
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
            if (!typeof(T).IsInterface)
            {
                return this.Set<T>();
            }

            var persistedObjectType = typeof(T);

            persistedObjectType = this._typeMapping[persistedObjectType];

            var method = this.GetType()
                             .GetMethod("Set")
                             .MakeGenericMethod(new[] { persistedObjectType });

            var result = method.Invoke(this, null) as DbSet;

            if (result != null)
            {
                return result.Cast<T>();
            }

            throw new ArgumentException(
                string.Format("A DbSet for the type {0} could not be created", typeof(T).Name));
        }

        private static IConfigurationManager ConfigurationManagerGuard(IConfigurationManager configuration)
        {
            Guard.ArgumentNotNull(configuration, "configuration");

            return configuration;
        }
    }
}