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
            foreach (var pS in baseObject.GetType().GetProperties().Where(prop => prop.CanWrite))
            {
                var s = pS;
                foreach (var pT in reference.GetType().GetProperties().Where(pT => pT.Name == s.Name))
                {
                    pT.GetSetMethod().Invoke(reference, new object[] { s.GetGetMethod().Invoke(baseObject, null) });
                }
            }

            return reference;
        }
    }
}