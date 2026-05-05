namespace SimpleNotificationSystem
{
    internal class NotificationService
    {
        public void SendNotification(INotification notification, string message)
        {
            notification.Send(message);
        }
    }
}
