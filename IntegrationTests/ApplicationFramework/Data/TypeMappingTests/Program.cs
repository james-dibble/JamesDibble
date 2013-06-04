namespace TypeMappingTests
{
    using System;

    using JamesDibble.ApplicationFramework.Configuration;
    using JamesDibble.ApplicationFramework.Data.Persistence.TypeMapping;
    using JamesDibble.ApplicationFramework.Data.Persistence.TypeMapping.Configuration;

    /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {
            ITypeMappingDictionary typeMappingDictionary = new TypeMappingDictionary();

            typeMappingDictionary = typeMappingDictionary.PopulateFromConfiguration();

            Console.ReadLine();
        }
    }
}
