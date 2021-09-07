using System;
using System.Collections.Generic;
using Compulsory1.Petshop.Domain.Models;

namespace Compulsory1.Petshop.Domain.IServices
{
    public interface IPetServices
    {
        List<Pet> GetPets();

        public Pet addPet(string name, DateTime birthdate, DateTime solddate, string color, double price,
            PetType petType);

        void remowePet(Pet deletePet);
        void updatePet(Pet oldPet, Pet updatePet);
    }
}