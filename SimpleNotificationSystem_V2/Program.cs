using System;
using System.Reflection.Metadata;

namespace SimpleNotificationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Welcome to the Notification System ---");
            UserRepository newUsrRepo = new UserRepository();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\n=== Registeration Portal ====");
                Console.WriteLine("-------------------------");
                Console.WriteLine("Enter 1 to register");
                Console.WriteLine("Enter 2 to update phone number");
                Console.WriteLine("Enter 3 to view user details");
                Console.WriteLine("Enter 4 to view all users");
                Console.WriteLine("Enter 5 to Delete a user");
                Console.WriteLine("Enter 6 to exit registration portal");
                Console.WriteLine("Please enter choice:");

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number:");
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\n-------- Register ------");
                        User newUser = new User();
                        newUsrRepo.Create(newUser);
                        Console.WriteLine("----- New User Registered ----");
                        break;

                    case 2:
                        Console.WriteLine("\n-----Update phone number---");
                        Console.WriteLine("Please enter old phone number:");
                        string OldNumber = Console.ReadLine() ?? string.Empty;
                        if (newUsrRepo.GetDetails(OldNumber) == null)
                        {
                            Console.WriteLine("Phone number not Registered");
                        }
                        else
                        {
                            User updatedUsr = new User();
                            newUsrRepo.Update(OldNumber, updatedUsr);
                            Console.WriteLine("User updated successfully");
                        }
                        break;

                    case 3:
                        Console.WriteLine("\n-----View Details ----");
                        Console.WriteLine("Please enter phone number to view details:");
                        string viewNum = Console.ReadLine() ?? string.Empty;

                        User? viewUser = newUsrRepo.GetDetails(viewNum);
                        if (viewUser == null)
                        {
                            Console.WriteLine("Phone number is not Registered");
                        }
                        else
                        {
                            Console.WriteLine($"\n{viewUser}\n");
                        }
                        break;

                    case 4:
                        Console.WriteLine("\n----Show Details of all Users----");
                        var allUsers = newUsrRepo.GetAll();
                        if (allUsers.Count == 0)
                        {
                            Console.WriteLine("No users registered yet.");
                        }
                        allUsers.Sort();
                        foreach (var u in allUsers)
                        {
                            Console.WriteLine(u);
                        }
                        break;

                    case 5:
                        Console.WriteLine("\n---- Delete a user ----");
                        Console.WriteLine("Please enter Phone number of the user to Delete:");
                        string DelNumber = Console.ReadLine() ?? string.Empty;

                        if (newUsrRepo.GetDetails(DelNumber) == null)
                        {
                            Console.WriteLine("This user is not Registered");
                        }
                        else
                        {
                            var DelUser = newUsrRepo.Delete(DelNumber);
                            Console.WriteLine("----User deleted----");
                        }
                        break;

                    case 6:
                        flag = false;
                        Console.WriteLine("\n----Exiting Registration Portal---");
                        break;
                }

            }
            User? user = null;
            Console.WriteLine("\n\n =======Notification Portal:=============");
            while (user == null)
            {
                Console.WriteLine("Enter your phone number to login and send notifications:");
                string usrPhno = Console.ReadLine() ?? string.Empty;
                user = newUsrRepo.GetDetails(usrPhno);
                if (user == null)
                    Console.WriteLine("Phone number not registered.");
            }


            while (true)
            {
                Console.WriteLine("\nChoose notification type:");
                Console.WriteLine("Enter 1 for Email");
                Console.WriteLine("Enter 2 for SMS");
                Console.WriteLine("Enter 3 to Exit application");
                Console.Write("Enter your choice:");
                string choice = Console.ReadLine() ?? string.Empty;

                INotification? selectedNotification = null;
                string receiverContact = "";

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter receiver's email: ");
                        receiverContact = Console.ReadLine() ?? string.Empty;
                        selectedNotification = new EmailNotification(user.Email, receiverContact);
                        break;
                    case "2":
                        Console.Write("Enter receiver's phone number: ");
                        receiverContact = Console.ReadLine() ?? string.Empty;
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
                string message = Console.ReadLine() ?? string.Empty;

                NotificationService service = new NotificationService();
                service.SendNotification(selectedNotification, message);

                Console.WriteLine("\nNotification sent successfully!");
            }
        }
    }
}