using MELI.Domain.Humans;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MELI.Infraestructure.EntifyFramwork
{
    public class MeliDbContext : DbContext
    {
        public MeliDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Human>()
                .HasIndex(b => b.DNA)
                .HasName("AlternateKey_DNA");
        }
        public DbSet<Human> Humans { get; set; }
    }
}
