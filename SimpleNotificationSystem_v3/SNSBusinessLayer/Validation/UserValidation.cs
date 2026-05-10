

using System.Text.RegularExpressions;
using SNSBusinessLayer.Exceptions;
using SNSModels;

namespace SNSBusinessLayer.Validation
{
    public class UserValidation
    {
        public void ValidatePhone(User usr)
        {
            string phno = usr.PhoneNumber;

            string regex = "^\\d{10}$";
            
            if(!Regex.IsMatch(phno,regex))
                throw new InvalidException("Phone number is not valid");
        }

        public void ValidateEmail(User usr)
        {
            string email = usr.Email;

            string regex = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";

            if(!Regex.IsMatch(email,regex))
                throw new InvalidException("Your email is invalid");
        }
    }    
}