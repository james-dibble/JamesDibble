// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeDomainObject2.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace FakeDomainModel
{
    using FakeInterfaces;

    /// <summary>
    /// The fake domain object 2.
    /// </summary>
    public class FakeDomainObject2 : IDomainObject1
    {
        /// <summary>
        /// Gets or sets the something.
        /// </summary>
        public string Something { get; set; }

        /// <summary>
        /// Gets or sets the something else.
        /// </summary>
        public double SomethingElse { get; set; }
    }
}