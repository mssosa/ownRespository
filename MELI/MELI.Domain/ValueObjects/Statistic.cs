using MELI.Domain.Humans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MELI.Domain.ValueObjects
{
    /// <summary>
    /// Class to manage stats abaout humans
    /// </summary>
    public class Statistic
    {
        /// <summary>
        /// Method for make statistics about humans, mutants and ratio
        /// </summary>
        /// <param name="humanList">List of all humans in database</param>
        /// <returns>A tuple with quantityHumans(an int), quantityMutants (an int)
        /// Ratio (a decimal).</returns>
        public (int quantityHumans, int quantityMutants, decimal Ratio) Evaluate(List<Human> humanList)
        {
            int quantityHumans = CalculateHumans(humanList);
            int quantityMutants = CalculateMutants(humanList);
            decimal Ratio = CalculateRatio(quantityHumans, quantityMutants);
            return (quantityHumans, quantityMutants, Ratio);
        }
        /// <summary>
        /// Specialized method for calculate ratio between humans and mutants.
        /// </summary>
        /// <param name="quantityHumans">Quantity of humans</param>
        /// <param name="quantityMutants">Quantity of mutants</param>
        /// <returns>result of calc or 0 if quantityHumans is zero</returns>
        private static decimal CalculateRatio(int quantityHumans, int quantityMutants)
        {
            if (quantityHumans==0)
                return 0;//for prevent divided by zero exception
            var result= (decimal) quantityMutants /(decimal) quantityHumans;
            return result;
        }
        /// <summary>
        /// Especializard method for calculate.
        /// </summary>
        /// <param name="humanList">List of all humans in database</param>
        /// <returns>quantity of mutants</returns>
        private static int CalculateMutants(List<Human> humanList)
        {
            return humanList.Where(x=>x.IsMutant==true).Count();
        }
        /// <summary>
        /// Especializard method for calculate.
        /// </summary>
        /// <param name="humanList">List of all humans in database</param>
        /// <returns>quantity of humans</returns>
        private int CalculateHumans(List<Human> humanList)
        {
            return humanList.Count();
        }
    }
}
