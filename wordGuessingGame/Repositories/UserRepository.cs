


using System.Collections.Concurrent;
using Npgsql;
using wordGuessingGame.Models;

namespace wordGuessingGame.Repositories
{
    public class UserRepository
    {

        private readonly string _connectionString = "Host=localhost;Port=5432;Database=wordgamedb;Username=postgres;Password=root";
        NpgsqlConnection connection;
        public string LoggedInUsername { get; set; } = "";

        public bool Register()
        {
            Console.WriteLine("-- Register --");
            Console.Write("Enter username: ");
            string username = Console.ReadLine() ?? "";
            Console.Write("Enter password: ");
            string password = Console.ReadLine() ?? "";

            string registerQuery = $"INSERT INTO users(username, password) VALUES('{username}', '{password}')";
            NpgsqlCommand command = new NpgsqlCommand(registerQuery, connection);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("User registered successfully!");
                    Console.ResetColor();
                    return true;
                }
            }
            catch (PostgresException e)
            {
                if (e.SqlState == "23505")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Username already exists!");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }

            return false;
        }

        public void UpdateScore(string username, int score)
        {
            string updateQuery = $"Update users set score = score+{score} where username = '{username}' returning score";
            NpgsqlCommand command = new NpgsqlCommand(updateQuery, connection);
            try
            {
                connection.Open();
                var result = command.ExecuteScalar();

                if (result != null)
                {
                    int updatedScore = Convert.ToInt32(result);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Score updated successfully! Your Overall score is {updatedScore}");
                    Console.ResetColor();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection?.Close();
            }
        }

        public bool Login()
        {
            Console.WriteLine("-- Login --");
            Console.Write("Enter username: ");
            string username = Console.ReadLine() ?? "";
            Console.Write("Enter password: ");
            string password = Console.ReadLine() ?? "";
            string loginQuery = $"select username from users where username='{username}' and password='{password}'";
            NpgsqlCommand command = new NpgsqlCommand(loginQuery, connection);

            try
            {
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string output = reader.GetString(0);
                    LoggedInUsername = output;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\n Welcome user : {output}");
                    Console.ResetColor();
                    connection?.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection?.Close();
            }
            return false;
        }

        public UserRepository()
        {
            connection = new NpgsqlConnection(_connectionString);

        }
    }
}