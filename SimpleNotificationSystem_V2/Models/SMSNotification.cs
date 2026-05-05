namespace SimpleNotificationSystem
{
    internal class SMSNotification : INotification
    {
        private string senderPhoneNumber;
        private string receiverPhoneNumber;

        public SMSNotification(string senderPhoneNumber, string receiverPhoneNumber)
        {
            this.senderPhoneNumber = senderPhoneNumber;
            this.receiverPhoneNumber = receiverPhoneNumber;
        }

        public string Message { get; set; } = string.Empty;
        public DateTime SentTime { get; set; }

        public void Send(string message)
        {
            Message = message;
            SentTime = DateTime.Now;

            Console.WriteLine("\n===== SMS Notification ====\n");
            Console.WriteLine($"From: {senderPhoneNumber}");
            Console.WriteLine($"To: {receiverPhoneNumber}");
            Console.WriteLine($"Sent Time: {SentTime}\n");
            Console.WriteLine($"Msg: {Message}");
            Console.WriteLine("========================\n");
        }
    }
}