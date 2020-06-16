using MELI.Domain.Humans;
using MELI.Domain.ValueObjects;
using System;
using Xunit;

namespace MELI.Domain.Test
{
    public class Mutant
    {
        [Theory]
        [InlineData("ATGCGA", "CAGTGC", "TTATGT", "AGAAGG","CCCCTA","TCACTG" )]
        public void IsMutant(params string[ ] dna)
        {
            var human = new Human(dna);
            human.IsMutant = HumanInspector.IsMutant(human);
            Assert.True(human.IsMutant);
        }
        [Theory]
        [InlineData("ATGCGA", "CAGTGC", "TTATTT", "AGACGG","GCGTCA","TCACTG")]
        public void NotIsMutant(params string[] dna)
        {
            var human = new Human(dna);
            human.IsMutant = HumanInspector.IsMutant(human);
            Assert.False(human.IsMutant);
        }

        [Theory]
        [InlineData("ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG")]
        [InlineData("ATGCGA", "CAGTGC", "TTATTT", "AGACGG","GCGTCA","TCACTG")]
        public void ValidationOk(params string[] dna)
        {
            try
            {
                HumanValidator.ValidateDNA(dna);
            }
            catch (Exception ex)
            {
                Assert.True(false,ex.Message);
            }

        }

        [Theory]
        [InlineData("ATGCG", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG")]
        [InlineData("ATGCGA", "CAGTGC", "TTATTT", "AGACGG", "GCGTCA")]
        public void ValidationFailByMatrix(params string[] dna)
        {
            Assert.Throws<ArgumentException>(() => HumanValidator.ValidateDNA(dna));
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidationFailByNullOrEmpty(params string[] dna)
        {
            Assert.Throws<ArgumentNullException>(()=>HumanValidator.ValidateDNA(dna));
        }
        [Theory]
        [InlineData("ATGCG", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG")]
        [InlineData("ATGCGA", "CAGTGC", "TTATTT", "AGACGG", "GCGTCA")]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("aBc1Ñ3", "dEFG45", "TTATTT", "AGACGG", "GCGTCA", "Gc7aCA")]
        public void ValidationFailAll(params string[] dna)
        {
            Assert.ThrowsAny<Exception>(() => HumanValidator.ValidateDNA(dna));
        }
    }
}
