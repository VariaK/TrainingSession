using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using SNSBusinessLayer.Exceptions;
using SNSModels;

namespace SNSBusinessLayer.Validation
{
    public class NotificationValidation
    {
        public void ValidateMsg(Notification n)
        {
            string msg = n.Message;

            if (string.IsNullOrWhiteSpace(msg))
                throw new InvalidException("You must enter a message");

            if (msg.Length < 5)
                throw new InvalidException("The message should be of atleast 5 characters.");

            if (msg.Length > 160)
                throw new InvalidException("The limit of a message is 160 characters. You have exceeded the limtit");
        }

        public void ValidateEmailRecipient(string email)
        {
            string regex = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";

            if (string.IsNullOrWhiteSpace(email))
                throw new InvalidException("Recipient email cannot be empty.");
            if (!Regex.IsMatch(email, regex))
                throw new InvalidException("Recipient email is invalid.");
        }

        public void ValidatePhoneRecipient(string phoneNumber)
        {
            string regex = "^\\d{10}$";
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new InvalidException("Recipient phone number cannot be empty.");
            if (!Regex.IsMatch(phoneNumber, regex))
                throw new InvalidException("Recipient phone number is invalid.");
        }
    }
}