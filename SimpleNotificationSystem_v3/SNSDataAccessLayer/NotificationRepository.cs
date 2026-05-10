using SNSModels;

namespace SNSDataAccessLayer
{
    public class NotificationRepository
    {
        public List<Notification> notifications = new List<Notification>();

        public void SaveNotification(Notification notification)
        {
            notifications.Add(notification);
        }

        public List<Notification> GetAllNotifications()
        {
            return notifications;
        }
    }

}

