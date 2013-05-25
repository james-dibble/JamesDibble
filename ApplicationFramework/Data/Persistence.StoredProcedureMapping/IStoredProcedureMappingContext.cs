// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStoredProcedureMappingContext.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Data.Persistence.StoredProcedureMapping
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Implementing classes define a manager for persistence sources managed
    /// by calling Stored Procedures.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces",
        Justification = "This interface may grow in the future.")]
    public interface IStoredProcedureMappingContext : IPersistenceManager
    { 
    }
}