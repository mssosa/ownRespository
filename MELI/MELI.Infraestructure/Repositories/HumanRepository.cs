using MELI.Aplication.Repositories;
using MELI.Domain.Humans;
using MELI.Infraestructure.EntifyFramwork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MELI.Infraestructure.Repositories
{
    /// <summary>
    /// Implementation of IHumanRepository and implements IDisponsable too
    /// for performance purposes
    /// </summary>
    public class HumanRepository : IHumanRepository, IDisposable
    {
        /// <summary>
        /// Constructor with DI
        /// </summary>
        /// <param name="db"></param>
        public HumanRepository(MeliDbContext db)
        {
            Db = db;
        }

        public MeliDbContext Db { get; set; }
        /// <summary>
        /// Implementation of Create method
        /// </summary>
        /// <param name="human">Human object</param>
        /// <returns>nothing</returns>
        public async Task Create(Human human)
        {
            await Db.Humans.AddAsync(human);
            await Db.SaveChangesAsync();
        }
        /// <summary>
        /// List all humans 
        /// </summary>
        /// <returns>List of Humans</returns>
        public async Task<List<Human>> GetAll()
        {
            return await Db.Humans.ToListAsync();
        }
        /// <summary>
        /// Search human by DNA
        /// </summary>
        /// <param name="dna"></param>
        /// <returns></returns>
        public async Task<Human> GetByDNA(string dna)
        {
            return await Db.Humans.Where(x => x.DNA == dna).FirstOrDefaultAsync();
        }
        ///Implementation of IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);///Call to Garbage Collector
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Db != null)
                {
                    Db.Dispose();
                    Db = null;
                }

            }
        }
    }
}
