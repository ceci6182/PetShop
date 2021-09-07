using System;
using System.Collections.Generic;
using Compulsory1.Petshop.DataAccess.Repositories;
using Compulsory1.Petshop.Domain.Models;

namespace Compulsory1.Petshop.DataAccess
{
    public class FakeDB
    {
        private static bool dataInit = false;
        
        private static int _petId = 1;
        private static List<Pet> _pets { get; set; } = new List<Pet>();
        private static List<PetType> _petTypes{ get; set; } = new List<PetType>();

        public FakeDB()
        {
            if (!dataInit)
            {
                InitData();
                dataInit = true;
            }
            
        }

        public void InitData()
        {
            PetType goat = new PetType
            {
                Id = 1,
                Name = "Goat"
            };

            PetType cat = new PetType
            {
                Id = 2,
                Name = "Cat"
            };

            PetType dog = new PetType
            {
                Id = 3,
                Name = "Dog"
            };

            _petTypes.Add(goat);
            _petTypes.Add(cat);
            _petTypes.Add(dog);

            
            Add("Gertrud", DateTime.Now, DateTime.Today, "brown", 10.09, goat);
            Add("Bob", DateTime.Parse("1/1/1"), DateTime.Parse("2/2/2"), "blue", 90.08, cat);
            Add("Ole", DateTime.Parse("1/3/12"), DateTime.Parse("2/5/2"), "brown", 3.98, cat);
            Add("Knud", DateTime.Parse("5/2/1"), DateTime.Parse("12/12/2"), "black", 4.08, cat);
            Add("Gerda", DateTime.Parse("5/4/3"), DateTime.Parse("1/2/3"), "red", 5.85, dog);
            Add("Fisk", DateTime.Parse("3/4/3"), DateTime.Parse("2/2/3"), "black", 7.33, dog);
        }

        public List<Pet> getPets()
        {
            return _pets;
        }
        
        public List<PetType> getPetTypes()
        {
            return _petTypes;
        }

        public Pet Add(string name, DateTime birthdate, DateTime solddate, string color, double price, PetType petType)
        {
            Pet pet = new Pet();
            pet.Id = _petId;
            pet.Name = name;
            pet.Birthdate = birthdate;
            pet.SoldDate = solddate;
            pet.Color = color;
            pet.Price = price;
            pet.PetType = petType;
            
            _petId++;
            _pets.Add(pet);
            return pet;
        }


        public void deletePet(int? deletePetId)
        {
            Pet deletePet = getPet(deletePetId);
            

            _pets.Remove(deletePet);
        }

        public void EditPet(Pet oldPet, Pet updatePet)
        {
            Pet petToEdit = getPet(oldPet.Id);
            petToEdit.Name = updatePet.Name;
            petToEdit.PetType = updatePet.PetType;
            petToEdit.Birthdate = updatePet.Birthdate;
            petToEdit.SoldDate = updatePet.SoldDate;
            petToEdit.Price = updatePet.Price;
            petToEdit.Color = updatePet.Color;
        }

        public Pet getPet(int? id)
        {
            Pet returnPet = null;
            foreach (var pet in _pets)
            {
                if (pet.Id == id)
                {
                    returnPet = pet;
                }
            }

            return returnPet;
        }
    }
}