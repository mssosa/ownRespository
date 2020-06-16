using MELI.Aplication.DTO;
using System.Threading.Tasks;

namespace MELI.Aplication.UseCases
{
    public interface IStat
    {
        Task<StatsDTO> CalculateStats();
    }
}