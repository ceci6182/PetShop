using System;
using System.Collections.Generic;
using Compulsory1.Petshop.Domain.Models;

namespace Compulsory1.Petshop.Core.IRepositories
{
    public interface IOwnerRepository
    {
        List<Owner> ReadPets();

        Owner Create(string firstname, string lastname, string address, string phoneNumber, string email);
        void delete(Owner deleteOwner);
        void edit(Owner oldOwner, Owner updateOwner);
    }
}