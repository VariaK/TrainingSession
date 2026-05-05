using System;

namespace SimpleNotificationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Welcome to the Notification System ---");
            Console.WriteLine("=== Please First Register yourself ====");
            User user = new User();
            
            while (true)
            {
                Console.WriteLine("\nChoose notification type:");
                Console.WriteLine("Enter 1 for Email");
                Console.WriteLine("Enter 2 for SMS");
                Console.WriteLine("Enter 3 to Exit application");
                Console.Write("Enter your choice:");
                string choice = Console.ReadLine();

                INotification selectedNotification = null;
                string receiverContact = "";

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter receiver's email: ");
                        receiverContact = Console.ReadLine();
                        selectedNotification = new EmailNotification(user.Email, receiverContact);
                        break;
                    case "2":
                        Console.Write("Enter receiver's phone number: ");
                        receiverContact = Console.ReadLine();
                        selectedNotification = new SMSNotification(user.PhoneNumber, receiverContact);
                        break;
                    case "3":
                        Console.WriteLine("Exiting the Notification System. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        continue;
                }

                Console.Write("Enter the message: ");
                string message = Console.ReadLine();

                NotificationService service = new NotificationService();
                service.SendNotification(selectedNotification, message);

                Console.WriteLine("\nNotification sent successfully!");
            }
        }
    }
}