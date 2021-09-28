using System.Collections.Generic;
using Compulsory1.Petshop.Core.IRepositories;
using Compulsory1.Petshop.Domain.Models;

namespace Compulsory1.Petshop.Infrastructure.Data.Repositories
{
    public class PetTypeRepository : IPetTypeRepository
    {
        
        readonly PetshopContext _ctx;

        public PetTypeRepository(PetshopContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<PetType> readPetTypes()
        {
            return _ctx.PetTypes;
        }
    }
}