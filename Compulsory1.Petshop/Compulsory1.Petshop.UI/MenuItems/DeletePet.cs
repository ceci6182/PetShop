namespace Compulsory1.Petshop.UI.MenuItems
{
    public class DeletePet : IMenuItem
    {
        public int ChoosingNumber { get; set; }
        public string Choice { get; set; } = StringConstants.DeletePetExplanation;
        public void SelectChoice(Printer printer)
        {
            printer.PrintAllPets();
            printer.DeletePet();
            printer.PrintEnter_GoBack();
        }
    }
}