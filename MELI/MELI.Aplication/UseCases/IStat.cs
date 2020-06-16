using MELI.Aplication.DTO;
using System.Threading.Tasks;

namespace MELI.Aplication.UseCases
{
    /// <summary>
    /// Interface for DI and SOLID
    /// </summary>
    public interface IStat
    {
        Task<StatsDTO> CalculateStats();
    }
}