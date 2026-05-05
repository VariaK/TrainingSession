
namespace SimpleNotificationSystem
{
    internal class User
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public User()
        {
            Console.Write("Please enter your name: ");
            Name = Console.ReadLine() ?? string.Empty;
            Console.Write("Please enter your email: ");
            Email = Console.ReadLine() ?? string.Empty;
            Console.Write("Please enter your phone number: ");
            PhoneNumber = Console.ReadLine() ?? string.Empty;
        }

        public User(string name, string email, string phno)
        {
            Name = name;
            Email = email;
            PhoneNumber = phno;
        }

        public override string ToString()
        {
            return $"Name: {Name} | Email: {Email} | Phone: {PhoneNumber}";
        }
    }
}