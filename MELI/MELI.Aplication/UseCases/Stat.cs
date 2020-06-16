using MELI.Aplication.DTO;
using MELI.Aplication.Repositories;
using MELI.Domain.ValueObjects;
using System.Threading.Tasks;

namespace MELI.Aplication.UseCases
{
    /// <summary>
    /// Class for UseCases abaout stats
    /// </summary>
    public class Stat : IStat
    {
        /// <summary>
        /// Method with DI of repository
        /// </summary>
        /// <param name="repo"></param>
        public Stat(IHumanRepository repo)
        {
            Repo = repo;
        }

        public IHumanRepository Repo { get; }
        /// <summary>
        /// Method specialized to calculate stats 
        /// </summary>
        /// <returns></returns>
        public async Task<StatsDTO> CalculateStats()
        {
            var auxHumanList = await Repo.GetAll();
            var calc = Factory.CreateStatics();
            (int quantityHumans, int quantityMutants, decimal Ratio) = calc.Evaluate(auxHumanList);
            return Factory.CreateStatsDTO(quantityHumans, quantityMutants, Ratio);
        }
    }
}
