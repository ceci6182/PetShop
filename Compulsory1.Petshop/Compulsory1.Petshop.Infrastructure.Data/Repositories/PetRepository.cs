using System;
using System.Collections.Generic;
using System.Linq;
using Compulsory1.Petshop.Core.IRepositories;
using Compulsory1.Petshop.Domain.Models;

namespace Compulsory1.Petshop.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        readonly PetshopContext _ctx;

        public PetRepository(PetshopContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Pet> ReadAll()
        {
            return _ctx.Pets;
        }

        public Pet Create(string name, DateTime birthdate, DateTime solddate, string color, double price, PetType petType)
        {
            throw new NotImplementedException();
        }

        public void delete(int? petId)
        {
            throw new NotImplementedException();
        }

        public void editPet(int? oldPetId, Pet updatePet)
        {
            throw new NotImplementedException();
        }

        public Pet ReadById(int id)
        {
            return _ctx.Pets.FirstOrDefault(p => p.Id == id);
        }
    }
}