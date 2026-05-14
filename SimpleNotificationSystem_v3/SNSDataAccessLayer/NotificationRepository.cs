using SNSModels;
using SNSDataAccessLayer.Interfaces;

namespace SNSDataAccessLayer
{
    public class NotificationRepository : INotificationRepository
    {
        public List<Notification> notifications = new List<Notification>();

        public void AddNotification(Notification notification)
        {
            notifications.Add(notification);
        }

        public Notification GetNotificationById(int id)
        {
            return notifications.FirstOrDefault(n => n.Id == id) ?? new Notification();
        }

        public List<Notification> GetAllNotifications()
        {
            return notifications;
        }

        public List<Notification> GetNotificationsByUserId(int userId)
        {
            return notifications.Where(n => n.FromUserId == userId).ToList();
        }
    }
}
