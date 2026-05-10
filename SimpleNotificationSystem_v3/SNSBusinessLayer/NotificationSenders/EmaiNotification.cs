using SNSBusinessLayer.Interfaces;
using SNSModels;

namespace SNSBusinessLayer.NotificationSenders
{
    public class EmailNotification: INotificationSender
    {
        public void Send(User user, Notification notification)
        {
            Console.WriteLine("\n-----Email Notification Sent Successfully-------");
            Console.WriteLine($"From: {notification.From}");
            Console.WriteLine($"To: {notification.To}");
            Console.WriteLine($"Message: {notification.Message}");
            Console.WriteLine("---------------------------------------------------");
        }

    }
    
}