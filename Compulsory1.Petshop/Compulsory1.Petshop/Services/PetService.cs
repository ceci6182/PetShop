using System;
using System.Collections.Generic;
using Compulsory1.Petshop.Core.IRepositories;
using Compulsory1.Petshop.Domain.IServices;
using Compulsory1.Petshop.Domain.Models;

namespace Compulsory1.Petshop.Core.Services
{
    public class PetService : IPetServices
    {
        private IPetRepository _petRepo;

        public PetService(IPetRepository petRepo)
        {
            _petRepo = petRepo;
        }
        public List<Pet> GetPets()
        {
            return _petRepo.ReadPets();
        }

        public Pet addPet(string name, DateTime birthdate, DateTime solddate, string color, double price,
            PetType petType)
        {
            return _petRepo.Create(name, birthdate, solddate, color, price, petType);
        }

        public void remowePet(Pet deletePet)
        {
            _petRepo.delete(deletePet);
        }

        public void updatePet(Pet oldPet, Pet updatePet)
        {
            _petRepo.editPet(oldPet, updatePet);
        }
    }
}