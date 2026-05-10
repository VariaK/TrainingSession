using SNSModels;

namespace SNSBusinessLayer.Interfaces
{
    public interface INotificationSender
    {
        void Send(User user, Notification notification);
    }
}