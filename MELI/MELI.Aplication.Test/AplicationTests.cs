using MELI.Aplication.DTO;
using MELI.Aplication.UseCases;
using MELI.Domain.Humans;
using MELI.Domain.ValueObjects;
using MELI.Infraestructure.EntifyFramwork;
using MELI.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MELI.Aplication.Test
{
    public class AplicationTests
    {
        private const string ConnectionString = "Server=.\\SQLExpress;Database=Meli;Trusted_Connection=True;MultipleActiveResultSets=true";

        private static MeliDbContext GenerateContext()
        {
            var options = new DbContextOptionsBuilder<MeliDbContext>()
                .UseSqlServer(ConnectionString).Options
                ;
            var context = new MeliDbContext(options);
            return context;
        }
        [Fact]
        public async Task TestIsMutant()
        {
            MeliDbContext context = GenerateContext();
            HumanRepository repo = new HumanRepository(context);
            //Manual injection
            IsMutant m = new IsMutant(repo);
            string[] DNA = new string[] { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };
            var isMutant=await m.isMutant(DNA);
            Assert.True(isMutant);
        }
        [Fact]
        public async Task TestIsntMutant()
        {
            MeliDbContext context = GenerateContext();
            HumanRepository repo = new HumanRepository(context);
            //Manual injection
            IsMutant m = new IsMutant(repo);
            string[] DNA = new string[] { "ATGCGA", "CAGTGC", "TTATTT", "AGACGG", "GCGTCA", "TCACTG" };
            var isMutant = await m.isMutant(DNA);
            Assert.False(isMutant);

        }


        [Fact]
        public void TestFactoryHuman()
        {
            var rdo=Factory.CreateHuman();
            Assert.True(rdo is Human);
        } 
        [Fact]
        public void TestFactoryHumanWithDNA()
        {
            string[] DNA = new string[] { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };
            var rdo=Factory.CreateHuman(DNA);
            Assert.True(rdo is Human);
        }


        [Fact]
        public void TestFactoryStatistic()
        {
            var rdo = Factory.CreateStatics();
            Assert.True(rdo is Statistic);
        }
        [Fact]
        public void TestFactoryStatsDTO()
        {
            var rdo = Factory.CreateStatsDTO(1,1,1m);
            Assert.True(rdo is StatsDTO);
        }

     
    }
}
