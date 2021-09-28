using System.Collections.Generic;
using Compulsory1.Petshop.Domain.Models;

namespace Compulsory1.Petshop.Core.IRepositories
{
    public interface IPetTypeRepository
    {
        IEnumerable<PetType> readPetTypes();
    }
}