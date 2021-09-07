namespace Compulsory1.Petshop.UI.MenuItems
{
    public interface IMenuItem
    {
        public int ChoosingNumber { get; set; }
        public string Choice { get; set; }
        public void SelectChoice(Printer printer);
    }
}