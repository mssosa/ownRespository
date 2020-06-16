using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MELI.Domain.ValueObjects
{
    public class HumanValidator
    {
        public static void ValidateDNA(string[] dna)
        {
            ValidateNull(dna);
            ValidateNoContent(dna);
            ValidateSimetry(dna);
            ValidateContent(dna);


        }

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

        private static void ValidateNoContent(string[] dna)
        {
            if (string.IsNullOrEmpty(dna[0]))
            {
                throw new ArgumentNullException("El campo DNA no puede ser vacio");
            }
        }

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

        private static void ValidateNull(string[] dna)
        {
            if (dna == null)
                throw new ArgumentNullException("El campo DNA no puede ser vacio");
        }
    }
}
