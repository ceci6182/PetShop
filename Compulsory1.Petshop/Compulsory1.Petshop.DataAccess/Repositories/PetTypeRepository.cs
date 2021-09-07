using System.Collections.Generic;
using Compulsory1.Petshop.Core.IRepositories;
using Compulsory1.Petshop.Domain.Models;

namespace Compulsory1.Petshop.DataAccess.Repositories
{
    public class PetTypeRepository : IPetTypeRepository
    {
        FakeDB fakeDb = new FakeDB();
        public List<PetType> readPetTypes()
        {
            return fakeDb.getPetTypes();
        }
    }
}