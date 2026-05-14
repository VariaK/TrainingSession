using SNSModels;

namespace SNSDataAccessLayer.Interfaces
{
    public interface INotificationRepository
    {
        void AddNotification(Notification notification);

        Notification GetNotificationById(int id);

        List<Notification> GetAllNotifications();

        List<Notification> GetNotificationsByUserId(int userId);
    }
}