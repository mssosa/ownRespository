using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MELI.Domain.ValueObjects
{
    /// <summary>
    /// Class specialized for validate all necesary in a human
    /// </summary>
    public class HumanValidator
    {
        /// <summary>
        /// Public method for make all validations to a DNA
        /// </summary>
        /// <param name="dna"></param>
        /// <return>Nothing to return but, if there are any error an exception is thrown</return>
        public static void ValidateDNA(string[] dna)
        {
            ValidateNull(dna);
            ValidateNoContent(dna);
            ValidateSimetry(dna);
            ValidateContent(dna);
        }

        /// <summary>
        /// Validate the content of DNA 
        /// Accept only A C G T values
        /// </summary>
        /// <param name="dna"></param>
        private static void ValidateContent(string[] dna)
        {
            foreach (var item in dna)
            {
                var reg = Regex.Matches(item, @"[0-9]|([a-z]|[ñ])|[BDEFHIJKLMNOPQRSUVWXYZÑ]");
                var errorCounter = reg.Count;
                if (errorCounter > 0)
                    throw new ArgumentException("El campo DNA debe contener solo las letras A C G T");
            }
        }
        /// <summary>
        /// Validate that tha value inside is NULL or EMPTY
        /// </summary>
        /// <param name="dna"></param>
        private static void ValidateNoContent(string[] dna)
        {
            if (string.IsNullOrEmpty(dna[0]))
            {
                throw new ArgumentNullException("El campo DNA no puede ser vacio");
            }
        }
        /// <summary>
        /// Validate simetry NxN
        /// </summary>
        /// <param name="dna"></param>
        private static void ValidateSimetry(string[] dna)
        {
            var xCant = dna.Count();
            foreach (var item in dna)
            {
                var y = item.Count();
                if (xCant != y)
                    throw new ArgumentException("El campo DNA debe ser una matriz NxN");
            }
        }
        /// <summary>
        /// Validate DNA equals to null
        /// </summary>
        /// <param name="dna"></param>
        private static void ValidateNull(string[] dna)
        {
            if (dna == null)
                throw new ArgumentNullException("El campo DNA no puede ser vacio");
        }
    }
}
