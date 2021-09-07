using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Compulsory1.Petshop.Core.IRepositories;
using Compulsory1.Petshop.Domain.Models;

namespace Compulsory1.Petshop.DataAccess.Repositories
{
    public class PetRepository: IPetRepository
    {
        FakeDB fakeDb = new FakeDB();
        public List<Pet> ReadPets()
        {
            return fakeDb.getPets();
        }

        public Pet Create(string name, DateTime birthdate, DateTime solddate, string color, double price, PetType petType)
        {

            return fakeDb.AddPet(name, birthdate, solddate, color, price, petType);
        }

        public void delete(Pet deletePet)
        {
            fakeDb.deletePet(deletePet.Id);
        }

        public void editPet(Pet oldPet, Pet updatePet)
        {
            fakeDb.EditPet(oldPet, updatePet);
        }
    }
}