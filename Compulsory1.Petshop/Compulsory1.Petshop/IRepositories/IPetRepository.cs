using System;
using System.Collections.Generic;
using Compulsory1.Petshop.Domain.Models;

namespace Compulsory1.Petshop.Core.IRepositories
{
    public interface IPetRepository
    {
        IEnumerable<Pet> ReadAll();

        Pet Create(string name, DateTime birthdate, DateTime solddate, string color, double price, PetType petType);
        void delete(int? petId);
        void editPet(int? oldPetId, Pet updatePet);

        Pet ReadById(int id);
    }
}