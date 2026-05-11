
using SNSModels;
using Npgsql;

namespace SNSDataAccessLayer
{
    public class UserRepository
    {
        List<User> UserList = new List<User>();
        private readonly string _connectionString =
            "Host=localhost;Port=5432;Database=notificationapp;Username=postgres;Password=root";
        NpgsqlConnection connection;
        public void SaveUser(User user)
        {
            UserList.Add(user);
            string InsertQuery = $"Insert into users(name,email,phonenumber) values('{user.Name}','{user.Email}','{user.PhoneNumber}')";
            NpgsqlCommand command = new NpgsqlCommand(InsertQuery, connection);
            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("user created successfully");
                    Console.ResetColor();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"error : {e.Message}");
            }
            finally
            {
                connection?.Close();
            }
        }

        public List<User> GetAllUsers()
        {
            return UserList;
        }

        public UserRepository()
        {
            connection = new NpgsqlConnection(_connectionString);
        }

    }
}