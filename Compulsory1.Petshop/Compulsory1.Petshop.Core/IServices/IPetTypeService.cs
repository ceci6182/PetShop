using System.Collections.Generic;
using Compulsory1.Petshop.Domain.Models;

namespace Compulsory1.Petshop.Domain.IServices
{
    public interface IPetTypeService
    {
        List<PetType> AllPetTypes();
    }
}