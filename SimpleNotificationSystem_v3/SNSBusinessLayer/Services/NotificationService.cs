using SNSBusinessLayer.Validation;
using SNSModels;
using SNSDataAccessLayer;
using SNSBusinessLayer.Interfaces;
using SNSBusinessLayer.NotificationSenders;
using SimpleNotificationSystemBusinessLayer.NotificationSender;

namespace SNSBusinessLayer.Services
{
    public class NotificationService
    {
        private readonly NotificationRepository repository;

        private readonly UserValidation userValidator;

        private readonly NotificationValidation notificationValidator;
        public NotificationService(NotificationRepository notificationRepository, UserValidation userValidation, NotificationValidation notificationValidation)
        {
            repository = notificationRepository;

            userValidator = userValidation;

            notificationValidator = notificationValidation;
        }

        public void SendNotification(User user, Notification notification)
        {
            // Validate notification

            notificationValidator.ValidateMsg(notification);
            INotificationSender sender = null;

            // Email notification

            if (notification.NotificationType == SNSModels.NotificationTypeEnum.Email)
            {
                userValidator.ValidateEmail(user);
                sender = new EmailNotification();
            }

            // SMS notification

            else if (notification.NotificationType == SNSModels.NotificationTypeEnum.SMS)
            {
                userValidator.ValidatePhone(user);

                sender = new smsNotification();
            }

            // Add sent date

            notification.SentTime = DateTime.Now;

            // Send notification

            sender.Send(user, notification);

            // Save notification

            repository.SaveNotification(notification);

            Console.WriteLine(
                "Notification saved successfully."
            );
        }

        public void DisplayNotifications()
        {
            var notifications =
                repository.GetAllNotifications();

            Console.WriteLine("\n===== Sent Notifications =====");
            if (notifications.Count == 0)
                Console.WriteLine("No notifications sent!\n");
            else
            {
                foreach (var notification in notifications)
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine($"From: {notification.From}");
                    Console.WriteLine($"To: {notification.To}");
                    Console.WriteLine($"Type: {notification.NotificationType}");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Message: {notification.Message}");
                    Console.ResetColor();

                    Console.WriteLine($"Sent Date: {notification.SentTime}");
                }
            }
        }
    }
}
