using System;
using System.Collections.Generic;
using Compulsory1.Petshop.Domain.Models;

namespace Compulsory1.Petshop.Domain.IServices
{
    public interface IPetServices
    {
        IEnumerable<Pet> GetPets();

        public Pet addPet(string name, DateTime birthdate, DateTime solddate, string color, double price,
            PetType petType);

        void RemovePet(int? petId);
        void updatePet(int? oldPetId, Pet updatePet);

        Pet FindPetById(int id);
    }
}