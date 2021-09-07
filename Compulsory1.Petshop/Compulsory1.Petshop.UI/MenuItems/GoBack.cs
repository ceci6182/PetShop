

using Compulsory1.Petshop.Core.Services;
using Compulsory1.Petshop.UI;
using Compulsory1.Petshop.UI.MenuItems;

namespace StarterWeek.VideoMenu
{
    public class GoBack : IMenuItem
    {
        public int ChoosingNumber { get; set; } = -1;
        public string Choice { get; set; } = StringConstants.GoBackExplanation;
        public void SelectChoice(Printer printer)
        {
            printer.PrintGoBack();
        }
    }
}