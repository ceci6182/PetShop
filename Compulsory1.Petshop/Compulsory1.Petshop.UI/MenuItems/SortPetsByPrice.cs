namespace Compulsory1.Petshop.UI.MenuItems
{
    public class SortPetsByPrice : IMenuItem
    {
        public int ChoosingNumber { get; set; }
        public string Choice { get; set; } = StringConstants.SortPetByPriceExplanation;
        public void SelectChoice(Printer printer)
        {
            printer.SortPetsByPrice();
        }
    }
}