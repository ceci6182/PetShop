using System;

namespace Compulsory1.Petshop.UI
{
    public class PetValidationUtil
    {
        public static bool PetNameValid (string name)
        {
            int length = name.Length;
            if (length < 3 || length > 40)
            {
                //todo exception?
                return false;
            }

            return true;
        }
        
        public static bool PetColorValid (string name)
        {
            int length = name.Length;
            if (length < 3 || length > 40)
            {
                //todo exception?
                return false;
            }

            return true;
        }
    }
}