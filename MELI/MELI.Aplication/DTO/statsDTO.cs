using System;
using System.Collections.Generic;
using System.Text;

namespace MELI.Aplication.DTO
{
    /// <summary>
    /// Class to return statistics values in JSON format
    /// </summary>
    public class StatsDTO
    {
        public StatsDTO(int quantityHumans, int quantityMutants, decimal ratio)
        {
            count_human_dna = quantityHumans;
            count_mutant_dna = quantityMutants;
            this.ratio = ratio;
        }

        public int count_mutant_dna { get; set; }
        public int count_human_dna { get; set; }
        public decimal ratio { get; set; }
    }
}
