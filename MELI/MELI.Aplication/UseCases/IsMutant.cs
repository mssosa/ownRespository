using MELI.Aplication.Repositories;
using MELI.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MELI.Aplication.UseCases
{
    public class IsMutant : IIsMutant
    {
        public IsMutant(IHumanRepository repo)
        {
            Repo = repo;
        }
        public IHumanRepository Repo { get; }


        public async Task<bool> isMutant(string[] dna)
        {
            HumanValidator.ValidateDNA(dna);
            var human = Factory.CreateHuman(dna);
            //First try insert human in db
            var exist = await Repo.GetByDNA(human.DNA);
            //if exist return its value, because it will be the same result
            if (exist != null)
                return (bool)exist.IsMutant;
            //if no exist, follow
            human.IsMutant = HumanInspector.IsMutant(human);
            //Send to create
            await Repo.Create(human);
            //reurn value
            return (bool)human.IsMutant;
        }

    }
}

