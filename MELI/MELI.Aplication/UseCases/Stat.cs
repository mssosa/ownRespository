using MELI.Aplication.DTO;
using MELI.Aplication.Repositories;
using MELI.Domain.ValueObjects;
using System.Threading.Tasks;

namespace MELI.Aplication.UseCases
{
    public class Stat : IStat
    {
        public Stat(IHumanRepository repo)
        {
            Repo = repo;
        }

        public IHumanRepository Repo { get; }

        public async Task<StatsDTO> CalculateStats()
        {
            var auxHumanList = await Repo.GetAll();
            var calc = Factory.CreateStatics();
            (int quantityHumans, int quantityMutants, decimal Ratio) = calc.Evaluate(auxHumanList);
            return Factory.CreateStatsDTO(quantityHumans, quantityMutants, Ratio);
        }
    }
}
