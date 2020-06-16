using MELI.Domain.Humans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MELI.Domain.ValueObjects
{
    public class Statistic
    {
        public (int quantityHumans, int quantityMutants, decimal Ratio) Evaluate(List<Human> humanList)
        {
            int quantityHumans = 0;
            int quantityMutants = 0;
            decimal Ratio = 0m;
            quantityHumans = CalculateHumans(humanList);
            quantityMutants = CalculateMutatns(humanList);
            Ratio = CalculateRatio(quantityHumans, quantityMutants);

            return (quantityHumans, quantityHumans, Ratio);
        }

        private static decimal CalculateRatio(int quantityHumans, int quantityMutants)
        {
            if (quantityHumans==0)
            {
                return 0;//for prevent divided by zero
            }
            return quantityMutants / quantityHumans;
        }

        private static int CalculateMutatns(List<Human> humanList)
        {
            return humanList.Where(x => x.IsMutant == false).Count();
        }

        private int CalculateHumans(List<Human> humanList)
        {
            return humanList.Where(x => x.IsMutant == false).Count();
        }
    }
}
