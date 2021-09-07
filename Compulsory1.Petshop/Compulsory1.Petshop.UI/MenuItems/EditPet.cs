namespace Compulsory1.Petshop.UI.MenuItems
{
    public class EditPet: IMenuItem
    {
        public int ChoosingNumber { get; set; }
        public string Choice { get; set; } = StringConstants.EditPetExplanation;
        public void SelectChoice(Printer printer)
        {
            printer.PrintAllPets();
            printer.EditPet();
            printer.PrintEnter_GoBack();
        }
    }
}