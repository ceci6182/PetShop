namespace Compulsory1.Petshop.UI
{
    public class StringConstants
    {
        #region Welcome

        public const string WelcomeGreeting = "Welcome to PetShop";

        #endregion


        #region GeneralisedStatements

        public const string FollowingOptions = "You now have following options";
        public const string AreYouSure = "Are you sure? (type yes or no)";
        public const string TryAgain = "something went wrong, please try again";
        public const string StayWithinTheScope = "stay within the scope, please";
        public const string TypeANumber = "Type a number, please";
        public const string PressEnterToGoBack = "Press Enter to go back";
        public const string PetIdNotFound = "ID does not match any pets";
        public const string InvalidProperty = "Invalid property";
        
        //todo optimer?
        public const string PetProperties = "name, type, price, color, birthdate, solddate";

        #endregion
        
        #region AllPets
        public const string AllPetsExplanation = "See all Pets";
        public const string AllPetsEmpty = "Your list of pets is currently empty";
        #endregion

        #region CreatePet

        public const string CreatePetExplanation = "Create a Pet";
        public const string CreatePetType = "Select Pet type (type Id of Pettype)";
        public const string CreatePetName = "Type name of Pet(2-40 chars)";
        public const string CreatePetBirthdate = "Type a Birthdate (in format 'MM/dd/yyyy')";
        public const string CreatePetSoldDate = "Type a Solddate (in format 'MM/dd/yyyy')";
        public const string CreatePetColor = "Type color of Pet(2-40 chars)";
        public const string CreatePetPrice = "Type price of Pet(has to be a positive decimal)";
        public const string CreatePetDone = "Pet with following properties created: ";
        #endregion

        #region DeletePet
        public const string DeletePetExplanation = "Delete a Pet";
        public const string DeletePetTypeId = "Type the ID of the pet you want to remove";
        public const string DeletePetDone = "Pet deleted";
        public const string DeletePetNotDone = "Pet not deleted";
        #endregion

        #region EditPet
        public const string EditPetExplanation = "Edit a Pet";
        public const string EditPetTypeId = "Type the ID of the pet you want to edit";
        public const string EditPetChooseProperty = "Type what you want to edit";
        public const string EditPetSuccessful = "Pet was editted";
        

        #endregion

        #region SearchPetsByType
        public const string SearchPetTypeExplanation = "Search Pet by Type";
        public const string SearchPetTypeId = "Type ID of the PetType, you want to search for";
        public const string SearchPetTypeFound= "Following pets found with chosen pettype";
        public const string SearchPetTypeNotFound= "No pets found with chosen pettype";
        #endregion

        #region SortPetsByPrice
        public const string SortPetByPriceExplanation = "Sort Pets by Price";
        #endregion

        #region GetFiveCheapestPets

        public const string FiveCheapestExplanation = "Get the five Cheapest pets";

        #endregion

        #region Exit
        public const string ExitExplanation = "End Application";
        

        #endregion

        #region Goback
        public const string GoBackExplanation = "Go back";
        

        #endregion
        
    }
}