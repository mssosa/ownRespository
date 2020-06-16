using MELI.Infraestructure.EntifyFramwork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MELI.WebApi
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MeliDbContext>
    {
        public MeliDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<MeliDbContext>();

            var connectionString = configuration.GetConnectionString("MeliConnection");

            builder.UseSqlServer(connectionString);

            return new MeliDbContext(builder.Options);
        }
    }
}
