using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Validation
{
    public class Validate
    {
        public bool NameValidate(string Name)
        {
            if (!Regex.IsMatch(Name, @"^[a-zA-Z'.]{1,40}$"))  //Validates a name. Allows up to 40 uppercase and lowercase characters and a few special characters that are common to some names
                return false;

            else
                return true;
        }

        public bool EmailValidate(string Email)
        {
            if (!Regex.IsMatch(Email, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$"))   //Validates an e-mail address.
                return false;

            else
                return true;
        }

        public bool PasswordValidate(string Pass)  
        {
            if (!Regex.IsMatch(Pass, @"^(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,10})$"))   //(Recommended not to use)Validates a strong password. It must be between 8 and 10 characters, contain at least one digit and one alphabetic character, and must not contain special characters.
                return false;

            else
                return true;
        }

        public bool CountValidate(string Count)
        {
            if (!Regex.IsMatch(Count, @"^\d+$"))   //Validates that the field contains an integer equal or greater than zero.
                return false;

            else
                return true;
        }

        public bool PriceValidate(string Price)
        {
            if (!Regex.IsMatch(Price, @"^\d+(\.\d\d)?$"))   //(Recommended Not to use)Validates a positive currency amount. If there is a decimal point, it requires 2 numeric characters after the decimal point. For example, 3.00 is valid but 3.1 is not.
                return false;

            else
                return true;
        }

    }
}
