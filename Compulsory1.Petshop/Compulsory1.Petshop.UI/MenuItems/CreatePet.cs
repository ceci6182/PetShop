using Compulsory1.Petshop.Domain.Models;

namespace Compulsory1.Petshop.UI.MenuItems
{
    public class CreatePet : IMenuItem
    {
        public int ChoosingNumber { get; set; }
        public string Choice { get; set; } = StringConstants.CreatePetExplanation;
        public void SelectChoice(Printer printer)
        {
            printer.CreatePet();
            printer.PrintEmpty();
            printer.PrintEnter_GoBack();
            
            

        }
    }
}