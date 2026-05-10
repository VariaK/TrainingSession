using SNSDataAccessLayer;
using SNSBusinessLayer.Validation;
using SNSBusinessLayer.Services;

namespace SNSBusinessLayer
{
    public static class ServiceFactory
    {
        public static NotificationService CreateNotificationService()
        {
            var notificationRepository = new NotificationRepository();
            var userValidation = new UserValidation();
            var notificationValidation = new NotificationValidation();
            return new NotificationService(notificationRepository, userValidation, notificationValidation);
        }
    }
}