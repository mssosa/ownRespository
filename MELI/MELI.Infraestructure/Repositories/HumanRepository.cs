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
    public class HumanRepository : IHumanRepository, IDisposable
    {
        public HumanRepository(MeliDbContext db)
        {
            Db = db;
        }

        public MeliDbContext Db { get; set; }

        public async Task Create(Human human)
        {
            await Db.Humans.AddAsync(human);
            await Db.SaveChangesAsync();
        }

        public async Task<List<Human>> GetAll()
        {
            return await Db.Humans.ToListAsync();
        }

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
