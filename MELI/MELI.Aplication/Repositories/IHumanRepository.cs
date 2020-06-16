using MELI.Domain.Humans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MELI.Aplication.Repositories
{
    /// <summary>
    /// A contract for repositories with methods needed
    /// </summary>
    public interface IHumanRepository
    {
        Task<List<Human>> GetAll();
        Task<Human> GetByDNA(string dna);
        Task Create(Human human);
    }
}
