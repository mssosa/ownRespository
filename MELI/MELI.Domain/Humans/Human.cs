using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MELI.Domain.Humans
{
    /// <summary>
    /// Class base of domain
    /// </summary>
    public class Human
    {
        /// <summary>
        /// Empty constructor for factory uses.
        /// </summary>
        public Human()
        {

        }
        /// <summary>
        /// Constructor for receipt and array and parsed to
        /// string
        /// </summary>
        /// <param name="_dna"></param>
        public Human(string[] _dna)
        {
            //Send to transform
            DnaArray = _dna;
        }
        [Key]
        public int HumanID { get; set; }
        [Required]
        public string DNA { get; set; }
        /// <summary>
        /// Allows null becaus it had te bo evaluated
        /// </summary>
        public bool? IsMutant { get; set; }

        /// <summary>
        /// Property for manage array
        /// </summary>
        [NotMapped]
        public string[] DnaArray
        {
            get
            {
                var charArray = DNA.Split(',');
                string[] r = new string[charArray.Count()];
                int i = 0;
                foreach (var item in charArray)
                {
                    r[i] = $"{item}";
                    i++;
                }

                return r;
            }
            set
            {
                bool first = true;
                foreach (var item in value)
                {
                    if (first)
                    {
                        DNA = item;
                        first = false;
                    }
                    else
                    {
                        DNA += $",{item}";
                    }
                };
            }
        }
       

    }
}
