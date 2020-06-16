using System;
using System.Collections.Generic;
using System.Text;

namespace MELI.Aplication.DTO
{
    public class StatsDTO
    {

        public StatsDTO(int quantityHumans, int quantityMutants, decimal ratio)
        {
            QuantityHumans = quantityHumans;
            QuantityMutants = quantityMutants;
            Ratio = ratio;
        }

        public int QuantityMutants { get; set; }
        public int QuantityHumans { get; set; }
        public decimal Ratio { get; set; }
    }
}
