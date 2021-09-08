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

        public void RemoveOwner(int? deleteOwner)
        {
            _ownerRepo.delete(deleteOwner);
        }

        public void UpdateOwner(int? oldOwnerId, Owner updateOwner)
        {
            _ownerRepo.edit(oldOwnerId, updateOwner);
        }
    }
}