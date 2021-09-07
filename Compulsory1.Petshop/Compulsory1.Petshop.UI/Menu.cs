using System;
using System.Collections.Generic;
using System.Linq;
using Compulsory1.Petshop.Core.IRepositories;
using Compulsory1.Petshop.Core.Services;
using Compulsory1.Petshop.DataAccess;
using Compulsory1.Petshop.DataAccess.Repositories;
using Compulsory1.Petshop.Domain.IServices;
using Compulsory1.Petshop.UI.MenuItems;
using Microsoft.Extensions.DependencyInjection;
using StarterWeek.VideoMenu;

namespace Compulsory1.Petshop.UI
{
    public class Menu
    {
        private Printer printer;
        public Menu()
        {

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetTypeRepository, PetTypeRepository>();
            serviceCollection.AddScoped<IPetServices, PetService>();
            serviceCollection.AddScoped<IPetTypeService, PetTypeServices>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var petService = serviceProvider.GetRequiredService<IPetServices>();
            var petTypeService = serviceProvider.GetRequiredService<IPetTypeService>();
            printer = new Printer(petService, petTypeService);
        }

        public void Start()
        {
            printer.PrintWelcome();
            StartMenuLoop(initMenu());
            
        }
        
        public List<IMenuItem> initMenu()
        {
            List<IMenuItem> returnList = new List<IMenuItem>();
            returnList.Add(new SeeAllPets());
            returnList.Add(new CreatePet());
            returnList.Add(new DeletePet());
            returnList.Add(new EditPet());
            returnList.Add(new SearchPetsByType());
            returnList.Add(new SortPetsByPrice());
            returnList.Add(new GetFiveCheapestPet());

            return CleanUpMenu(returnList, true);
        }
        
        

        public void StartMenuLoop(List<IMenuItem> menuItems)
        {
            int choice;
            bool matchFound = false;
            printer.PrintMenu(menuItems);
            while ((choice = GetMenuSelection()) != 0)
            {
                matchFound = false;
                foreach (var menuItem in menuItems)
                {
                    if (menuItem.ChoosingNumber == choice)
                    {
                        printer.PrintEmpty();
                        menuItem.SelectChoice(printer);
                        printer.PrintMenu(menuItems);
                        matchFound = true;
                    }
                }

                if (!matchFound)
                {
                    printer.PrintTryAgain();
                    printer.PrintMenu(menuItems);
                }
                
            }
        }

        private int GetMenuSelection()
        {
            var selectionString = Console.ReadLine();
            int selection;
            if (int.TryParse(selectionString, out selection))
            {
                return selection;
            }

            return -1;
        }

        public List<IMenuItem> CleanUpMenu (List<IMenuItem> menu, bool needsExit)
        {
            //Makes sure there isnt an accidental Exit option in the menu
            menu.RemoveAll(m => m.ChoosingNumber == -1);
            
            //todo get rid of possible duplicates menu items
            int id = 1;
            foreach (var menuItem in menu)
            {
                menuItem.ChoosingNumber = id;
                    id++;
                
            }
            
            if (needsExit)
            {
                IMenuItem exit = new Exit();
                exit.ChoosingNumber = 0;
                menu.Add(exit);
            }
            else
            {
                IMenuItem GoBack = new GoBack();
                GoBack.ChoosingNumber = 0;
                menu.Add(GoBack);
            }

            menu = menu.OrderBy(m => m.ChoosingNumber).ToList();
            return menu;
        }
        
        
    }
}