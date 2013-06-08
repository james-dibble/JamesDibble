namespace TypeMappingTests
{
    using JamesDibble.ApplicationFramework.Data.Persistence.TypeMapping;
    using System;

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
