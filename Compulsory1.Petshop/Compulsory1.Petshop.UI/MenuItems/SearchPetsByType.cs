namespace Compulsory1.Petshop.UI.MenuItems
{
    public class SearchPetsByType : IMenuItem
    {
        public int ChoosingNumber { get; set; }
        public string Choice { get; set; } = StringConstants.SearchPetTypeExplanation;
        public void SelectChoice(Printer printer)
        {
            printer.SearchPetByType();
        }
    }
}