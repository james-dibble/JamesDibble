﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace System
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The string extensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// The to url string.
        /// </summary>
        /// <param name="stringToFix">
        /// The string to fix.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ToUrlString(this string stringToFix)
        {
            return stringToFix.Replace(" ", "-").ToLower();
        }

        /// <summary>
        /// The URL string to reverse.
        /// </summary>
        /// <param name="stringToReverse">
        /// The string to reverse.
        /// </param>
        /// <returns>
        /// The <see cref="string"/> from once it came.
        /// </returns>
        public static string FromUrlString(this string stringToReverse)
        {
            return stringToReverse.Replace("-", " ");
        }

        /// <summary>
        /// Normalize new line characters.
        /// </summary>
        /// <param name="input">
        /// The input string.
        /// </param>
        /// <returns>
        /// The <see cref="string"/> normalized.
        /// </returns>
        public static string NormalizeNewLines(this string input)
        {
            return Regex.Replace(input, "(\\n|\\\\n|\\r|\\\\r)+", Environment.NewLine, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// The compute hash.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ComputeHash(this string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);

            return Convert.ToBase64String(new HMACSHA256().ComputeHash(bytes));
        }

        /// <summary>
        /// The compute hash.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="salt">
        /// The salt.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ComputeHash(this string value, string salt)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            var saltBytes = Encoding.UTF8.GetBytes(salt);

            return Convert.ToBase64String(new HMACSHA256(saltBytes).ComputeHash(bytes));
        }

        /// <summary>
        /// Pluralise a string given the length of a given collection.
        /// </summary>
        /// <param name="value">
        /// The string to pluralise.
        /// </param>
        /// <param name="collection">
        /// The collection to count.
        /// </param>
        /// <returns>
        /// The pluralised <see cref="string"/>.
        /// </returns>
        public static string Pluralise(this string value, IEnumerable<object> collection)
        {
            return value.Pluralise(collection == null ? 0 : collection.Count());
        }

        /// <summary>
        /// Pluralise a string given the length of a given collection.
        /// </summary>
        /// <param name="value">
        /// The string to pluralise.
        /// </param>
        /// <param name="count">
        /// The count.
        /// </param>
        /// <returns>
        /// The pluralised <see cref="string"/>.
        /// </returns>
        public static string Pluralise(this string value, int count)
        {
            if (count == 1)
            {
                return value;
            }

            string ending;

            switch (value.TrimEnd().Last())
            {
                case 'y':
                    value = value.TrimEnd('y');
                    ending = "ies";
                    break;

                case 'o':
                    ending = "es";
                    break;

                default:
                    ending = "s";
                    break;
            }

            return string.Concat(value, ending);
        }
    }
}