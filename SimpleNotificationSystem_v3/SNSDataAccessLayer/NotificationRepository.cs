using System.Security.Cryptography;
using Npgsql;
using SNSModels;

namespace SNSDataAccessLayer
{
    public class NotificationRepository
    {
        public List<Notification> notifications = new List<Notification>();
        string connectionString = "Host=localhost;Port=5432;Database=notificationapp;Username=postgres;Password=root";
        NpgsqlConnection connection;

        public void SaveNotification(Notification notification)
        {


            string insertCmd = $"Insert into Notifications(FromAdd,ToAdd,Message,NotificationType,SentTime) values ('{notification.From}','{notification.To}','{notification.Message}','{notification.NotificationType}','{notification.SentTime.ToString("yyyy-MM-dd HH:mm:ss")}')";
            NpgsqlCommand command = new NpgsqlCommand(insertCmd, connection);
            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("notification inserted into database !");
                    Console.ResetColor();
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"error : {e.Message}");
                Console.ResetColor();
            }
            finally
            {
                connection?.Close();
            }
        }

        public List<Notification> GetAllNotifications(User user)
        {

            string Selectcmd = $"select * from notifications where FromAdd = '{user.Email}' or FromAdd= '{user.PhoneNumber}' ";
            NpgsqlCommand command = new NpgsqlCommand(Selectcmd, connection);
            try
            {
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Notification notification = new Notification()
                    {
                        From = reader["FromAdd"].ToString() ?? "",
                        To = reader["ToAdd"].ToString() ?? "",
                        Message = reader["Message"].ToString() ?? "",
                        NotificationType = Enum.Parse<NotificationTypeEnum>(reader["NotificationType"].ToString() ?? ""),
                        SentTime = Convert.ToDateTime(reader["SentTime"])
                    };
                    notifications.Add(notification);

                }
                reader.Close();

            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"error : {e.Message}");
                Console.ResetColor();
            }
            finally
            {
                connection?.Close();
            }
            return notifications;
        }
        public NotificationRepository()
        {
            connection = new NpgsqlConnection(connectionString);
        }
    }

}

