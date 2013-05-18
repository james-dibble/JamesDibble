// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntityContext.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicaitonFramework.Data.Persistence.EntityFramework
{
    using JamesDibble.ApplicationFramework.Data.Persistence;

    /// <summary>
    /// Implementing classes define a manager for persistence sources managed
    /// by the Entity Framework.
    /// </summary>
    public interface IEntityContext : IPersistenceManager
    {
    }
}