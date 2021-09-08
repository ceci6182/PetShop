using System;
using System.Collections.Generic;
using Compulsory1.Petshop.Domain.Models;

namespace Compulsory1.Petshop.Core.IRepositories
{
    public interface IOwnerRepository
    {
        List<Owner> ReadOwners();

        Owner Create(string firstname, string lastname, string address, string phoneNumber, string email);
        void delete(int? deleteOwnerId);
        void edit(int? oldOwnerID, Owner updateOwner);
    }
}