using System;

namespace SimpleNotificationSystem
{
    internal interface INotification
    {
        public string Message { get; set; }
        public DateTime SentTime { get; set; }

        public void Send(string message);
    }
}