using System;
using System.Collections.Generic;
using Compulsory1.Petshop.Domain.Models;

namespace Compulsory1.Petshop.Core.IRepositories
{
    public interface IPetRepository
    {
        List<Pet> ReadPets();

        Pet Create(string name, DateTime birthdate, DateTime solddate, string color, double price, PetType petType);
        void delete(Pet deletePet);
        void editPet(Pet oldPet, Pet updatePet);
    }
}