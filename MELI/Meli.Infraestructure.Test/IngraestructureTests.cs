using MELI.Infraestructure.EntifyFramwork;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using System.Threading.Tasks;
using MELI.Infraestructure.Repositories;
using MELI.Domain.Humans;

namespace Meli.Infraestructure.Test
{
    public class IngraestructureTests
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
        public async Task TestGetAll()
        {
            MeliDbContext context = GenerateContext();
            HumanRepository repo = new HumanRepository(context);

            var listOfHumans = await repo.GetAll();
            Assert.True(listOfHumans.Count > 0);

        }


        [Theory]
        [InlineData("ATGCGA,CAGTGC,TTATGT,AGAAGG,CCCCTA,TCACTG")]
        [InlineData("ATGCGA,CAGTGC,TTATTT,AGACGG,GCGTCA,TCACTG")]
        public async Task TestGetOne(string dna)
        {
            MeliDbContext context = GenerateContext();
            HumanRepository repo = new HumanRepository(context);

            var oneHuman = await repo.GetByDNA(dna);
            Assert.True(oneHuman != null);
        }
        [Theory]
        [InlineData("ATGCGT,CTGTGC,TAATGT,ACAAGG,CCCCTA,TCACTG")]
        public async Task TestCreate(string dna)
        {
            MeliDbContext context = GenerateContext();
            HumanRepository repo = new HumanRepository(context);
            Human human = new Human();
            human.DNA = dna;
            //Create one
            await repo.Create(human);
            //Search in BD if exist
            var oneHuman = await repo.GetByDNA(dna);

            Assert.True(oneHuman != null);
        }
        [Fact]
        public async Task TestDispose()
        {
            MeliDbContext context = GenerateContext();
            HumanRepository repo = new HumanRepository(context);
            var listOfHumans = await repo.GetAll();
            if (listOfHumans != null)
            {
                //Call to garbage collector
                repo.Dispose();
            }
            //this method have to fail
            await Assert.ThrowsAnyAsync<NullReferenceException>(
                async () =>
                listOfHumans = await repo.GetAll()
                );

        }
    }
}
