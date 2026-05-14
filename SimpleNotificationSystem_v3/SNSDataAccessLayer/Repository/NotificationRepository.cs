using Microsoft.EntityFrameworkCore;
using SNSDataAccessLayer.Contexts;
using SNSDataAccessLayer.Interfaces;
using SNSModels;

namespace SNSDataAccessLayer.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly NotificationSystemContext context;

        public NotificationRepository(NotificationSystemContext context)
        {
            this.context = context;
        }

        public void AddNotification(Notification notification)
        {
            context.Notifications.Add(notification);

            context.SaveChanges();
        }

        public List<Notification> GetAllNotifications()
        {
            return context.Notifications
                          .Include(n => n.User)
                          .ToList();
        }

        public Notification GetNotificationById(int id)
        {
            return context.Notifications
                          .Include(n => n.User)
                          .FirstOrDefault(n => n.Id == id)!;
        }

        public List<Notification> GetNotificationsByUserId(int userId)
        {
            return context.Notifications
                          .Include(n => n.User)
                          .Where(n => n.FromUserId == userId)
                          .ToList();
        }
    }
}