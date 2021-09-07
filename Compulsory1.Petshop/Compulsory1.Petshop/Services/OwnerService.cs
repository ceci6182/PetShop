using System.Collections.Generic;
using Compulsory1.Petshop.Core.IRepositories;
using Compulsory1.Petshop.Domain.IServices;
using Compulsory1.Petshop.Domain.Models;

namespace Compulsory1.Petshop.Core.Services
{
    public class OwnerService : IOwnerService
    {
        private IOwnerRepository _ownerRepo;

        public OwnerService(IOwnerRepository ownerRepo)
        {
            _ownerRepo = ownerRepo;
        }
        
        public List<Owner> GetOwners()
        {
            return  _ownerRepo.ReadOwners();
        }

        public Owner AddOwner(string firstname, string lastname, string address, string phoneNumber, string email)
        {
            return _ownerRepo.Create(firstname, lastname, address, phoneNumber, email);
        }

        public void RemoveOwner(Owner deleteOwner)
        {
            _ownerRepo.delete(deleteOwner);
        }

        public void UpdateOwner(Owner oldOwner, Owner updateOwner)
        {
            _ownerRepo.edit(oldOwner, updateOwner);
        }
    }
}