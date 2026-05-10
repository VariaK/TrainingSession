using System.Globalization;
using System.Transactions;

namespace SNSModels
{
    public class User
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public User()
        {
        }
    }
}