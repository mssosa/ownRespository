using MELI.Aplication.DTO;
using MELI.Domain.Humans;
using MELI.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MELI.Aplication
{
    public class Factory
    {
        public static Human CreateHuman()
        {
            return new Human();
        }
        public static Human CreateHuman(string[] dna)
        {
            return new Human(dna);
        }
        public static Statistic CreateStatics()
        {
            return new Statistic();
        }
        public static StatsDTO CreateStatsDTO(int quantityHumans, int quantityMutants, decimal Ratio)
        {
            return new StatsDTO(quantityHumans,  quantityMutants,  Ratio);
        }

      
    }
}
