using System;
using System.Runtime.InteropServices;

namespace Compulsory1.Petshop.Domain.Models
{
    public class Pet
    {
        public int? Id {
            get;
            set;
        }
        public string Name { get; set; }
        public PetType PetType { get; set; }
        public DateTime Birthdate{ get; set; }
        public DateTime SoldDate{ get; set; }
        public string Color{ get; set; }    
        public double Price{ get; set; }

        public override string ToString()
        {
            string returnString = "";
            if (Id.HasValue)
            {
                returnString += $"ID = {Id}, ";
            }

            returnString +=
                $"Pet type = {PetType.Name}, name = {Name}, BirthDate = {Birthdate}, Sold Date = {SoldDate}, Color = {Color}, Price = {Price}";
            return returnString;
        }
    }
}