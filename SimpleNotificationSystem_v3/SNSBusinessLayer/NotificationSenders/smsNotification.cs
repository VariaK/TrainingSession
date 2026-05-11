using SNSBusinessLayer.Interfaces;
using SNSModels;
namespace SimpleNotificationSystemBusinessLayer.NotificationSender
{
    public class smsNotification : INotificationSender
    {
        public void Send(User user, Notification notification)
        {
            Console.WriteLine("\n--------SMS Notification Sent Successfully------");
            Console.WriteLine($"From: {notification.From}");
            Console.WriteLine($"To: {notification.To}");
            Console.WriteLine($"Message: {notification.Message}");
            Console.WriteLine("---------------------------------------------------\n"); ;
        }

    }

}