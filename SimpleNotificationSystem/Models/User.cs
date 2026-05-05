
namespace SimpleNotificationSystem
{
    internal class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public User()
        {
            Console.Write("Please enter your name: ");
            Name = Console.ReadLine();
            Console.Write("Please enter your email: ");
            Email = Console.ReadLine();
            Console.Write("Please enter your phone number: ");
            PhoneNumber = Console.ReadLine();
        }

        public User(string name, string email, string phno)
        {
            Name = name;
            Email = email;
            PhoneNumber = phno;
        }
    }
}