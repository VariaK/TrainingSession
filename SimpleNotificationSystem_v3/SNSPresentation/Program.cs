
using SNSBusinessLayer.Exceptions;
using SNSBusinessLayer.Services;
using SNSBusinessLayer.Validation;
using SNSDataAccessLayer.Contexts;
using SNSDataAccessLayer.Repositories;
using SNSModels;

namespace SNSPresentation
{
    static class Program
    {
        public static void Main()
        {
            Console.WriteLine("\n\n ----------- Welcome to Notification Service -----------\n");

            // Manual Dependency Injection Setup for a Console App
            var context = new NotificationSystemContext();
            var notificationRepository = new NotificationRepository(context);
            var userRepository = new UserRepository(context);
            var userValidation = new UserValidation();
            var notificationValidation = new NotificationValidation();

            var userService = new UserService(userRepository);
            var notificationService = new NotificationService(notificationRepository, userValidation, notificationValidation);

            User currentUser = new User(); // This will hold the registered user

            try
            {
                Console.WriteLine("\n =====Registration Portal====");
                Console.WriteLine("Please register yourself!");
                Console.Write("Enter your name: ");
                currentUser.Name = Console.ReadLine() ?? "";

                Console.Write("Enter your email: ");
                currentUser.Email = Console.ReadLine() ?? "";

                Console.Write("Enter your phone number: ");
                currentUser.PhoneNumber = Console.ReadLine() ?? "";

                userValidation.ValidateEmail(currentUser);
                userValidation.ValidatePhone(currentUser);

                userService.RegisterUser(currentUser); // Use the service to register
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nRegistration Successful!");
                Console.ResetColor();

            }
            catch (InvalidException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n Error: {ex.Message}");
                Console.ResetColor();
                return;
            }

            bool running = true;

            while (running)
            {
                Console.WriteLine(
                    "\n========== MENU =========="
                );

                Console.WriteLine(
                    "1. Send Email Notification"
                );

                Console.WriteLine(
                    "2. Send SMS Notification"
                );

                Console.WriteLine(
                    "3. Show All Notifications"
                );

                Console.WriteLine(
                    "4. Exit"
                );

                Console.Write("Enter your option: ");

                int option;
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.ResetColor();
                    continue;
                }
                switch (option)
                {
                    case 1:
                        try
                        {
                            Notification emailNotification = new Notification();
                            emailNotification.NotificationType = SNSModels.NotificationTypeEnum.Email;
                            emailNotification.From = currentUser.Email;
                            emailNotification.FromUserId = currentUser.Id; // Set FromUserId

                            Console.Write("Enter receiver email: ");
                            emailNotification.To = Console.ReadLine() ?? "";

                            Console.Write("Enter message: ");
                            emailNotification.Message = Console.ReadLine() ?? "";

                            notificationValidation.ValidateEmailRecipient(emailNotification.To);
                            notificationValidation.ValidateMsg(emailNotification);

                            notificationService.SendNotification(currentUser, emailNotification);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Email notification sent successfully!");
                            Console.ResetColor();
                        }
                        catch (InvalidException ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(ex.Message);
                            Console.ResetColor();
                        }
                        break;

                    case 2:
                        try
                        {
                            Notification smsNotification = new Notification();
                            smsNotification.NotificationType = SNSModels.NotificationTypeEnum.SMS;
                            smsNotification.From = currentUser.PhoneNumber;
                            smsNotification.FromUserId = currentUser.Id; // Set FromUserId

                            Console.Write("Enter receiver phone number: ");
                            smsNotification.To = Console.ReadLine() ?? "";

                            Console.Write("Enter message: ");
                            smsNotification.Message = Console.ReadLine() ?? "";

                            notificationValidation.ValidatePhoneRecipient(smsNotification.To);
                            notificationValidation.ValidateMsg(smsNotification);

                            notificationService.SendNotification(currentUser, smsNotification);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("SMS notification sent successfully!");
                            Console.ResetColor();
                        }
                        catch (InvalidException ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\n Error: {ex.Message}");
                            Console.ResetColor();
                        }
                        break;

                    case 3:
                        notificationService.DisplayNotifications();
                        break;

                    case 4:
                        running = false;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Thank you!");
                        Console.ResetColor();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enter valid option");
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}