using System.Collections.Generic;
using Compulsory1.Petshop.Core.IRepositories;
using Compulsory1.Petshop.Domain.IServices;
using Compulsory1.Petshop.Domain.Models;

namespace Compulsory1.Petshop.Core.Services
{
    public class PetTypeServices : IPetTypeService
    {

        private IPetTypeRepository _petTypeRepository;
        
        public PetTypeServices (IPetTypeRepository petTypeRepository)
        {
            _petTypeRepository = petTypeRepository;
        }
        
        public IEnumerable<PetType> AllPetTypes()
        {
           return _petTypeRepository.readPetTypes();
        }
    }
}