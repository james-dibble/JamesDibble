// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityContext.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Data.Persistence.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

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
            this.Configuration.AutoDetectChangesEnabled = true;
        }

        /// <summary>
        /// Find an <see cref="IPersistedObject"/>
        /// </summary>
        /// <param name="searchCriteria">
        /// An object defining how to find the <typeparamref name="T"/>.
        /// </param>
        /// <typeparam name="T">
        /// The type of <see cref="IPersistedObject"/>.
        /// </typeparam>
        /// <returns>
        /// An <see cref="IPersistedObject"/> retrieved from the persistence source.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0",
            Justification = "I is.")]
        public T Find<T>(IPersistenceSearcher<T> searchCriteria) where T : class, IPersistedObject
        {
            Guard.ArgumentNotNull(searchCriteria, "searchCriteria");

            var discoveredObject = this.GetSet<T>()
                .Includes(searchCriteria.Includes.ToArray())
                .SingleOrDefault(searchCriteria.Predicate);

            return discoveredObject;
        }

        /// <summary>
        /// Find a collection of <see cref="IPersistedObject"/>
        /// </summary>
        /// <param name="searchCriteria">
        /// An object defining how to find the collection of <typeparamref name="T"/>.
        /// </param>
        /// <typeparam name="T">
        /// The type of <see cref="IPersistedObject"/>.
        /// </typeparam>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of <see cref="IPersistedObject"/> retrieved from the persistence source.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0",
            Justification = "I is.")]
        public IEnumerable<T> Find<T>(IPersistenceCollectionSearcher<T> searchCriteria) where T : class, IPersistedObject
        {
            Guard.ArgumentNotNull(searchCriteria, "searchCriteria");

            var collection = this.GetSet<T>()
                .Includes(searchCriteria.Includes.ToArray())
                .Where(searchCriteria.Predicate);

            return collection;
        }

        /// <summary>
        /// Update an object that already exists in the persistence source.
        /// </summary>
        /// <param name="updatedObject">
        /// The object that has changed.
        /// </param>
        /// <typeparam name="T">
        /// The type of <see cref="IPersistedObject"/>.
        /// </typeparam>
        public void Change<T>(T updatedObject) where T : class, IPersistedObject
        {
            this.Set(typeof(T)).Attach(updatedObject);
            ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.ChangeObjectState(
                updatedObject, EntityState.Modified);
        }

        /// <summary>
        /// Insert a new object into the persistence source.
        /// </summary>
        /// <param name="newObject">
        /// The new object.
        /// </param>
        /// <typeparam name="T">
        /// The type of <see cref="IPersistedObject"/>.
        /// </typeparam>
        public void Add<T>(T newObject) where T : class, IPersistedObject
        {
            this.Set(typeof(T)).Add(newObject);
        }

        /// <summary>
        /// Delete an object from the persistence source.
        /// </summary>
        /// <param name="objectToRemove">
        /// The object to remove.
        /// </param>
        /// <typeparam name="T">
        /// The type of <see cref="IPersistedObject"/>.
        /// </typeparam>
        public void Remove<T>(T objectToRemove) where T : class, IPersistedObject
        {
            this.Set<T>().Remove(objectToRemove);
        }

        /// <summary>
        /// Create an instance of <typeparamref name="T"/> and add it to the object graph if applicable.
        /// </summary>
        /// <typeparam name="T">
        /// The type of <see cref="IPersistedObject"/>.
        /// </typeparam>
        /// <returns>
        /// The new instance of <typeparamref name="T"/>.
        /// </returns>
        public T Create<T>() where T : class, IPersistedObject
        {
            return this.Set(typeof(T)).Create() as T;
        }

        /// <summary>
        /// Save changes that have been added to the <see cref="IPersistenceManager"/>.
        /// </summary>
        public void Commit()
        {
            this.SaveChanges();
        }

        private static IConfigurationManager ConfigurationManagerGuard(IConfigurationManager configuration)
        {
            Guard.ArgumentNotNull(configuration, "configuration");

            return configuration;
        }

        private IQueryable<T> GetSet<T>() where T : class, IPersistedObject
        {
            if (typeof(T).IsInterface)
            {
                throw new ArgumentException(
                    "Why on earth do think that you can get an entity set of a non concrete type?");
            }

            return this.Set<T>();
        }
    }
}