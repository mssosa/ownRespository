using System.Threading.Tasks;

namespace MELI.Aplication.UseCases
{
    /// <summary>
    /// Interface for DI and SOLID
    /// </summary>
    public interface IIsMutant
    {
        Task<bool> isMutant(string[] dna);
    }
}