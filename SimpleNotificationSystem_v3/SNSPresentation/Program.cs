
using SNSBusinessLayer.Exceptions;
using SNSBusinessLayer.Services;
using SNSBusinessLayer.Validation;
using SNSDataAccessLayer;
using SNSModels;

namespace SNSPresentation
{
    static class Program
    {
        public static void Main()
        {
            Console.WriteLine("\n\n ----------- Welcome to Notification Service -----------\n");



            User user = new User();
            try
            {
                Console.WriteLine("\n =====Registration Portal====");
                Console.WriteLine("Please register yourself!");
                Console.Write("Enter your name: ");
                user.Name = Console.ReadLine() ?? "";

                Console.Write("Enter your email: ");
                user.Email = Console.ReadLine() ?? "";

                Console.Write("Enter your phone number: ");
                user.PhoneNumber = Console.ReadLine() ?? "";

                UserValidation validator = new UserValidation();
                validator.ValidateEmail(user);
                validator.ValidatePhone(user);

                UserRepository userRepo = new UserRepository();
                userRepo.SaveUser(user);
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

            NotificationValidation notificationValidation = new NotificationValidation();
            NotificationService service = SNSBusinessLayer.ServiceFactory.CreateNotificationService();

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

                            emailNotification.From = user.Email;

                            Console.Write("Enter receiver email: ");
                            emailNotification.To =
                                Console.ReadLine() ?? "";

                            Console.Write(
                                "Enter message: "
                            );
                            emailNotification.Message =
                                Console.ReadLine() ?? "";

                            notificationValidation.ValidateEmailRecipient(emailNotification.To);
                            notificationValidation.ValidateMsg(emailNotification);

                            service.SendNotification(user, emailNotification);
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
                            Notification smsNotification =
                                new Notification();

                            smsNotification.NotificationType = SNSModels.NotificationTypeEnum.SMS;
                            smsNotification.From = user.PhoneNumber;

                            Console.Write(
                                "Enter receiver phone number: "
                            );
                            smsNotification.To =
                                Console.ReadLine() ?? "";

                            Console.Write(
                                "Enter message: "
                            );
                            smsNotification.Message =
                                Console.ReadLine() ?? "";

                            notificationValidation.ValidatePhoneRecipient(smsNotification.To);
                            notificationValidation.ValidateMsg(smsNotification);

                            service.SendNotification(
                                user,
                                smsNotification
                            );
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

                        service.DisplayNotifications();

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