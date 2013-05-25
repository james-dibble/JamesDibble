// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntityContext.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Data.Persistence.EntityFramework
{
    using System.Diagnostics.CodeAnalysis;

    using JamesDibble.ApplicationFramework.Data.Persistence;

    /// <summary>
    /// Implementing classes define a manager for persistence sources managed
    /// by the Entity Framework.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces",
        Justification = "This interface may expand in the future.")]
    public interface IEntityContext : IPersistenceManager
    {
    }
}