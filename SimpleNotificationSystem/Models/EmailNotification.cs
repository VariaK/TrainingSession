namespace SimpleNotificationSystem
{
    internal class EmailNotification : INotification
    {
        private string senderEmail;
        private string receiverEmail;

        public EmailNotification(string senderEmail, string receiverEmail)
        {
            this.senderEmail = senderEmail;
            this.receiverEmail = receiverEmail;
        }

        public string Message { get; set; }
        public DateTime SentTime { get; set; }
        public void Send(string message)
        {
            Message = message;
            SentTime = DateTime.Now;

            Console.WriteLine("\n===== Email Notification ====\n");
            Console.WriteLine($"From: {senderEmail} ");
            Console.WriteLine($"To: {receiverEmail} ");
            Console.WriteLine($"Sent Date: {SentTime} \n");
            Console.WriteLine($"Msg: {Message} ");
            Console.WriteLine("========================\n");

        }
    }
}
