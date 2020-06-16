using System.Threading.Tasks;

namespace MELI.Aplication.UseCases
{
    public interface IIsMutant
    {
        Task<bool> isMutant(string[] dna);
    }
}