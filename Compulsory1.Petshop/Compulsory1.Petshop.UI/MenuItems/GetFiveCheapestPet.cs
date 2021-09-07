namespace Compulsory1.Petshop.UI.MenuItems
{
    public class GetFiveCheapestPet : IMenuItem
    {
        public int ChoosingNumber { get; set; }
        public string Choice { get; set; } = StringConstants.FiveCheapestExplanation;
        public void SelectChoice(Printer printer)
        {
            printer.GetFiveCheapestPets();
        }
    }
}