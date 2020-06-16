using MELI.Domain.Humans;
using MELI.Domain.ValueObjects;
using System;
using System.Collections.Generic;
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
        [InlineData("aBc1�3", "dEFG45", "TTATTT", "AGACGG", "GCGTCA", "Gc7aCA")]
        public void ValidationFailAll(params string[] dna)
        {
            Assert.ThrowsAny<Exception>(() => HumanValidator.ValidateDNA(dna));
        }

        [Theory]
        [InlineData(100,40,0.4)]
        public void ValidationStatistics(int qH, int qM,decimal r)
        {
            List<Human> listInvented = new List<Human>();
            for (int i = 0; i < qH; i++)
            {
                string[] dna=new string[]{"AAAA","ACCC", "ACCC", "ACCC" };
                var m = new Human(dna);
                if (i<40)
                {
                    m.IsMutant = true;
                }
                else
                {
                    m.IsMutant = false;
                }
                listInvented.Add(m);
            }
            //simulation list
            Statistic s = new Statistic();
            var rdo = s.Evaluate(listInvented);
            Assert.True(
                rdo.quantityHumans == qH
                &&
                rdo.quantityMutants == qM
                &&
                rdo.Ratio == r
                ); 
        }

    }
}
