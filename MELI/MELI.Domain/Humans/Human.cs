using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MELI.Domain.Humans
{
    public class Human
    {
        public Human()
        {

        }
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
