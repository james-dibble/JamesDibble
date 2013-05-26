// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectExtensions.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace System
{
    using System.Linq;

    /// <summary>
    /// The system extensions.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// The copy to.
        /// </summary>
        /// <param name="baseObject">
        /// The base object.
        /// </param>
        /// <param name="reference">
        /// The object to copy to.
        /// </param>
        /// <typeparam name="T">
        /// The return type.
        /// </typeparam>
        /// <returns>
        /// The reference object as a clone of the base object.
        /// </returns>
        public static T CopyTo<T>(this T baseObject, T reference)
        {
            foreach (var baseProperty in baseObject.GetType().GetProperties().Where(prop => prop.CanWrite))
            {
                var savedCopy = baseProperty;
                foreach (var referenceProperty in reference.GetType().GetProperties().Where(pT => pT.Name == savedCopy.Name))
                {
                    referenceProperty.GetSetMethod().Invoke(reference, new object[] { savedCopy.GetGetMethod().Invoke(baseObject, null) });
                }
            }

            return reference;
        }
    }
}