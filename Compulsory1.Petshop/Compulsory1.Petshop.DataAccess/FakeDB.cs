using System;
using System.Collections.Generic;
using System.Linq;
using Compulsory1.Petshop.DataAccess.Repositories;
using Compulsory1.Petshop.Domain.Models;

namespace Compulsory1.Petshop.DataAccess
{
    public class FakeDB
    {
        private static bool dataInit = false;
        
        private static int _petId = 1;
        private static int _petTypeId = 1;
        private static int _ownerId = 1;
        private static List<Pet> _pets { get; set; } = new List<Pet>();
        private static List<PetType> _petTypes{ get; set; } = new List<PetType>();
        
        private static List<Owner> _owners{ get; set; } = new List<Owner>();

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
            AddPetType("goat");
            AddPetType("dog");
            AddPetType("cat");
            
            AddPet("Gertrud", DateTime.Now, DateTime.Today, "brown", 10.09, _petTypes.ElementAt(1));
            AddPet("Bob", DateTime.Parse("1/1/1"), DateTime.Parse("2/2/2"), "blue", 90.08, _petTypes.ElementAt(2));
            AddPet("Ole", DateTime.Parse("1/3/12"), DateTime.Parse("2/5/2"), "brown", 3.98, _petTypes.ElementAt(2));
            AddPet("Knud", DateTime.Parse("5/2/1"), DateTime.Parse("12/12/2"), "black", 4.08, _petTypes.ElementAt(1));
            AddPet("Gerda", DateTime.Parse("5/4/3"), DateTime.Parse("1/2/3"), "red", 5.85, _petTypes.ElementAt(0));
            AddPet("Fisk", DateTime.Parse("3/4/3"), DateTime.Parse("2/2/3"), "black", 7.33, _petTypes.ElementAt(1));
        }

        public List<Pet> getPets()
        {
            return _pets;
        }
        
        public List<PetType> getPetTypes()
        {
            return _petTypes;
        }

        public List<Owner> getOwners()
        {
            return _owners;
        }

        public Pet AddPet(string name, DateTime birthdate, DateTime solddate, string color, double price, PetType petType)
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

        public PetType AddPetType(string name)
        {
            PetType petType = new PetType();
            petType.Id = _petTypeId;
            petType.Name = name;
            
            _petTypes.Add(petType);
            _petTypeId++;
            return petType;
        }

        public Owner AddOwner(string firstname, string lastname, string address, string phoneNumber, string email)
        {
            Owner owner = new Owner();
            owner.Id = _ownerId;
            owner.FirstName = firstname;
            owner.LastName = lastname;
            owner.Address = address;
            owner.PhoneNumber = phoneNumber;
            owner.Email = email;
            
            _owners.Add(owner);
            _ownerId++;
            return owner;
        }


        public void deletePet(int? deletePetId)
        {
            Pet deletePet = getPet(deletePetId);
            

            _pets.Remove(deletePet);
        }

        public void DeleteOwner(int? deleteOwnerId)
        {

            _owners.Remove(getOwner(deleteOwnerId));
        }

        public void EditPet(int? oldPetId, Pet updatePet)
        {
            Pet petToEdit = getPet(oldPetId);
            petToEdit.Name = updatePet.Name;
            petToEdit.PetType = updatePet.PetType;
            petToEdit.Birthdate = updatePet.Birthdate;
            petToEdit.SoldDate = updatePet.SoldDate;
            petToEdit.Price = updatePet.Price;
            petToEdit.Color = updatePet.Color;
        }

        public void EditOwner(Owner oldOwner, Owner updateOwner)
        {
            Owner ownerToEdit = getOwner(oldOwner.Id);
            ownerToEdit.FirstName = updateOwner.FirstName;
            ownerToEdit.LastName = updateOwner.LastName;
            ownerToEdit.Address = updateOwner.Address;
            ownerToEdit.PhoneNumber = updateOwner.PhoneNumber;
            ownerToEdit.Email = ownerToEdit.PhoneNumber;
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
        
        public Owner getOwner(int? id)
        {
            Owner returnOwner = null;
            foreach (var owner in _owners)
            {
                if (owner.Id == id)
                {
                    returnOwner = owner;
                }
            }

            return returnOwner;
        }
    }
}