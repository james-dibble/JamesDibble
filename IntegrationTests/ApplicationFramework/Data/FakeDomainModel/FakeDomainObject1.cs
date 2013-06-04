// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeDomainObject1.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace FakeDomainModel
{
    using FakeInterfaces;

    /// <summary>
    /// The fake domain object 1.
    /// </summary>
    public class FakeDomainObject1 : IDomainObject2
    {
        /// <summary>
        /// Gets or sets the anything.
        /// </summary>
        public int Anything { get; set; }
    }
}