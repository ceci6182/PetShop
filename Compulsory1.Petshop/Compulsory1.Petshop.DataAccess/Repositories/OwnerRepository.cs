using System.Collections.Generic;
using Compulsory1.Petshop.Core.IRepositories;
using Compulsory1.Petshop.Domain.Models;

namespace Compulsory1.Petshop.DataAccess.Repositories
{
    public class OwnerRepository :IOwnerRepository
    {
        private FakeDB _fakeDb = new FakeDB();
        public List<Owner> ReadOwners()
        {
           return _fakeDb.getOwners();
        }

        public Owner Create(string firstname, string lastname, string address, string phoneNumber, string email)
        {
            return _fakeDb.AddOwner(firstname, lastname, address, phoneNumber, email);
        }

        public void delete(Owner deleteOwner)
        {
            _fakeDb.DeleteOwner(deleteOwner.Id);
        }

        public void edit(Owner oldOwner, Owner updateOwner)
        {
            _fakeDb.EditOwner(oldOwner, updateOwner);
        }
    }
}