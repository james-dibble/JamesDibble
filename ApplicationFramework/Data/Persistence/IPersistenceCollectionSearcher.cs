// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPersistenceCollectionSearcher.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Data.Persistence
{
    /// <summary>
    /// Implementing classes define an object to search a persistence source for a collection.
    /// </summary>
    public interface IPersistenceCollectionSearcher
    {
        /// <summary>
        /// Gets the maximum number of records to return.
        /// </summary>
        int Limit { get; }
    }
}