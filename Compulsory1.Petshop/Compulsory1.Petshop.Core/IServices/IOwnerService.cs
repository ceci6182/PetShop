using System.Collections.Generic;
using Compulsory1.Petshop.Domain.Models;

namespace Compulsory1.Petshop.Domain.IServices
{
    public interface IOwnerService
    {
        List<Owner> GetOwners();

        public Owner AddOwner(string firstname, string lastname, string address, string phoneNumber, string email);

        void RemoveOwner(int? deleteOwner);
        void UpdateOwner (int? oldOwnerId, Owner  updateOwner );
    }
}