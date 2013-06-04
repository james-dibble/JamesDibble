// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDomainObject1.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace FakeInterfaces
{
    using JamesDibble.ApplicationFramework.Data.Persistence;

    /// <summary>
    /// The DomainObject1 interface.
    /// </summary>
    public interface IDomainObject1 : IPersistedObject
    {
        /// <summary>
        /// Gets or sets the something.
        /// </summary>
        string Something { get; set; }

        /// <summary>
        /// Gets or sets the something else.
        /// </summary>
        double SomethingElse { get; set; }
    }
}