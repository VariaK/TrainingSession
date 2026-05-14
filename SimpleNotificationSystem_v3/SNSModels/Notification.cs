namespace SNSModels
{
    public enum NotificationTypeEnum { Email, SMS }

    public class Notification
    {
        public int Id { get; set; }
        public string From { get; set; } = string.Empty;
        public int FromUserId { get; set; }

        public User User { get; set; }
        public string To { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;

        public NotificationTypeEnum NotificationType { get; set; }

        public DateTime SentTime { get; set; }
    }
}