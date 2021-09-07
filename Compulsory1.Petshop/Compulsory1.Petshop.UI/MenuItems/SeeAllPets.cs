
namespace Compulsory1.Petshop.UI.MenuItems
{
    public class SeeAllPets : IMenuItem
    {
        public int ChoosingNumber { get; set; }
        public string Choice { get; set; } = StringConstants.AllPetsExplanation;

        public void SelectChoice(Printer printer)
        {
            printer.Menu_SeeAllPets();
        }

    }
}