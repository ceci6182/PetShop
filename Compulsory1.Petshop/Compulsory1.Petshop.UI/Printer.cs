using System;
using System.Collections.Generic;
using System.Linq;
using Compulsory1.Petshop.Domain.IServices;
using Compulsory1.Petshop.Domain.Models;
using Compulsory1.Petshop.UI.MenuItems;

namespace Compulsory1.Petshop.UI
{
    public class Printer
    {
        private readonly IPetServices _petServices;
        private readonly IPetTypeService _petTypeService;

        public Printer(IPetServices petService, IPetTypeService petTypeService)
        {
            _petServices = petService;
            _petTypeService = petTypeService;
        }

        #region Print Methods
        public void Print(string text)
        {
            Console.WriteLine(text);
        }

        public void PrintWelcome()
        {
            Print(StringConstants.WelcomeGreeting);
            Print(StringConstants.FollowingOptions);
        }

        public void PrintEnter_GoBack()
        {
            Print(StringConstants.PressEnterToGoBack);
            Console.ReadLine();
        }

        public void PrintEmpty()
        {
            Print(" ");
        }
        
        public void PrintAllPets()
        {
            List<Pet> allpets = _petServices.GetPets();
            if (allpets.Count == 0)
            {
                Print(StringConstants.AllPetsEmpty);
            }
            else
            {
                foreach (var pet in allpets)
                {
                    Print(pet.ToString());
                }
            }
        }
        private void PrintPetTypes()
        {
            List<PetType> petTypes = _petTypeService.AllPetTypes();
            foreach (PetType petType in petTypes)
            {
                Print(petType.ToString());
            }
        }

        public void PrintTryAgain()
        {
            Print(StringConstants.TryAgain);
        }

        public void PrintMenu(List<IMenuItem> menuItems)
        {
            Print("");
            PrintMenuScope(menuItems);
            foreach (var menuItem in menuItems)
            {
                Print(MenuItemToString(menuItem));
            }

        }
        
        public void PrintMenuScope(List<IMenuItem> menu)
        {
            Print($"select between 0-{menu.Count-1}");
        }
        
        public void PrintGoBack()
        {
            Print(StringConstants.GoBackExplanation);
        }

        public void PrintList_Pet(List<Pet> list)
        {
            foreach (var pet in list)
            {
                Print(pet.ToString());
            }
        }
        
        #endregion

        #region Type Methods
        public string TypePetName()
        {
            string petName = null;
            while (petName == null)
            {
                Print(StringConstants.CreatePetName);
                string temp = Console.ReadLine();
                if(PetValidationUtil.PetNameValid(temp))
                {
                    petName = temp;
                }
                else
                {
                    PrintTryAgain();
                }
            }

            return petName;
        }
        
         private double TypePetPrice()
        {
            double petPrice = -1;
            while (petPrice < 0)
            {
                Print(StringConstants.CreatePetPrice);
                bool parse = false;
                while (!parse)
                {
                    parse = double.TryParse(Console.ReadLine(), out petPrice);
                    if (!parse)
                    {
                        PrintTryAgain();
                    }
                    
                }
            }

            return petPrice;
        }

        private string TypePetColor()
        {
            string petColor = null;
            while (petColor == null)
            {
                Print(StringConstants.CreatePetColor);
                string temp = Console.ReadLine();
                if(PetValidationUtil.PetColorValid(temp))
                {
                    petColor = temp;
                }
                else
                {
                    PrintTryAgain();
                }
            }

            return petColor;
        }

        private DateTime TypePetBirthDate()
        {
            DateTime birthday = new DateTime();
            bool valid = false;
            while (!valid)
            {
                Print("");
                Print(StringConstants.CreatePetBirthdate);
                valid = DateTime.TryParse(Console.ReadLine(), out birthday);
                if (!valid)
                {
                    Print(StringConstants.TryAgain);
                }
            }

            return birthday;
        }
        
        private DateTime TypePetSoldDate()
        {
            DateTime soldDate = new DateTime();
            bool valid = false;
            while (!valid)
            {
                Print("");
                Print(StringConstants.CreatePetSoldDate);
                valid = DateTime.TryParse(Console.ReadLine(), out soldDate);
                if (!valid)
                {
                    Print(StringConstants.TryAgain);
                }
            }

            return soldDate;
        }

        #endregion

        #region Select methods

        private PetType SelectPetType_ID()
        {
            PetType returnPetType = null;
            while (returnPetType == null)
            {
                Print("");
                PrintPetTypes();
                Print(StringConstants.CreatePetType);
                
                bool parse = false;
                int typeId = -1;
                while (!parse)
                {
                    
                    parse = int.TryParse(Console.ReadLine(), out typeId);
                    if (!parse)
                    {
                        Print("");
                        Print(StringConstants.TypeANumber);
                    }

                }
                
                foreach (PetType petType in _petTypeService.AllPetTypes())
                {
                    if (petType.Id == typeId)
                    {
                        returnPetType = petType;
                    }
                }

                if (returnPetType == null)
                {
                    PrintTryAgain();
                }
                
            }

            return returnPetType;
        }
        
        public bool SelectAreYouSure()
        {
            
            //todo optimer
            while (true)
            {
                Print(StringConstants.AreYouSure);
                var answer = Console.ReadLine().ToLower();
                if (answer.Equals("yes"))
                {
                    return true;
                }

                if (answer.Equals("no"))
                {
                    return false;
                }
                
                PrintTryAgain();
                
            }

        }

        #endregion
        
        #region MenuItem Methods

        public void Menu_SeeAllPets()
        {
            PrintAllPets();
            PrintEmpty();
            PrintEnter_GoBack();
        }
        
        private static string MenuItemToString(IMenuItem menuItem)
        {
            var returnString = $"select {menuItem.ChoosingNumber} to {menuItem.Choice}";
            return returnString;
        }
        public void CreatePet()
        {
            string petName = TypePetName();
            PetType petType = SelectPetType_ID();
            DateTime birthdate = TypePetBirthDate();
            DateTime soldDate = TypePetSoldDate();
            string color = TypePetColor();
            double price = TypePetPrice();

            Pet newPet = _petServices.addPet(petName, birthdate, soldDate, color, price, petType);
            Print(StringConstants.CreatePetDone);
            Print(newPet.ToString());
        }
        
        public void DeletePet()
        {
            Pet deletePet = null;
            int id = -1;
            
            bool parse = false;
            while (!parse)
            {
                Print(StringConstants.DeletePetTypeId);
                parse = int.TryParse(Console.ReadLine(), out id);
                if (!parse)
                {
                    Print(StringConstants.TypeANumber);
                }
            }

            
            foreach (Pet pet in _petServices.GetPets())
            {
                if (pet.Id == id)
                {
                    deletePet = pet;
                }
            }

            if (deletePet == null)
            {
                Print(StringConstants.PetIdNotFound);
                
            }
            else
            {
                if (SelectAreYouSure())
                {
                    _petServices.RemovePet(deletePet.Id);
                    Print(StringConstants.DeletePetDone);
                    
                }
                else
                {
                    Print(StringConstants.DeletePetNotDone);
                }
               
            }

        }

        public void EditPet()
        {
            int id = -1;
            Pet editPet = null;
            
               
               bool parse = false;
               while (!parse)
               {
                   Print(StringConstants.EditPetTypeId);
                   parse = int.TryParse(Console.ReadLine(), out id);
                   if (!parse)
                   {
                       Print(StringConstants.TypeANumber);
                   }
               }
               
               foreach (Pet pet in _petServices.GetPets())
               {
                   if (pet.Id == id)
                   {
                       editPet = pet;
                   }
               }

               if (editPet == null)
               {
                   Print(StringConstants.PetIdNotFound);
                
               }
               else
               {
                   Pet updatePet = editPet;
                   bool petUpdated = false;
                   //todo optimer?
                   Print(StringConstants.EditPetChooseProperty +"(" + StringConstants.PetProperties + ", back)");
                   
                   string choosenProperty = Console.ReadLine().ToLower();
                   switch (choosenProperty)
                   {
                       case "name":
                           updatePet.Name = TypePetName();
                           petUpdated = true;
                           break;
                       case "type":
                           updatePet.PetType = SelectPetType_ID();
                           petUpdated = true;
                           break;
                       case "birthdate":
                           updatePet.Birthdate = TypePetBirthDate();
                           petUpdated = true;
                           break;
                       case "solddate":
                           updatePet.SoldDate = TypePetSoldDate();
                           petUpdated = true;
                           break;
                       case "color":
                           updatePet.Color = TypePetColor();
                           petUpdated = true;
                           break;
                       case "price":
                           updatePet.Price = TypePetPrice();
                           petUpdated = true;
                           break;
                       default:
                           Print(StringConstants.InvalidProperty);
                           break;
                   }

                   if (petUpdated)
                   {
                       _petServices.updatePet(editPet.Id, updatePet);
                       Print(StringConstants.EditPetSuccessful);
                   }
               }
               

        }
        
        public void SearchPetByType()
        {
            int petTypeId = -1;
            bool parse = false;
            while (!parse)
            {
                PrintPetTypes();
                Print(StringConstants.SearchPetTypeId);
                parse = int.TryParse(Console.ReadLine(), out petTypeId);
                if (!parse)
                {
                    Print(StringConstants.TypeANumber);
                }
            }

            List<Pet> matchingPets = new List<Pet>();

            foreach (var pet in _petServices.GetPets())
            {
                if (pet.PetType.Id == petTypeId)
                {
                    matchingPets.Add(pet);
                }
            }

            if (matchingPets.Count == 0)
            {
                Print(StringConstants.SearchPetTypeNotFound);
            }
            else
            {
                Print(StringConstants.SearchPetTypeFound);
                foreach (var pet in matchingPets)
                {
                    Print(pet.ToString());
                }
            }
            
            PrintEnter_GoBack();

        }
        
        public void SortPetsByPrice()
        {
            List<Pet> priceSortList = _petServices.GetPets().OrderBy(p => p.Price).ToList();
            PrintList_Pet(priceSortList);
            PrintEnter_GoBack();
        }

        #endregion


        public void GetFiveCheapestPets()
        {
            List<Pet> priceSortList = _petServices.GetPets().OrderBy(p => p.Price).ToList();
            List<Pet> fiveCheapest = new List<Pet>();
            for (int i = 0; i < 5; i++)
            {
                fiveCheapest.Add(priceSortList.ElementAt(i));
            }
            PrintList_Pet(fiveCheapest);
            PrintEnter_GoBack();
        }
    }
}