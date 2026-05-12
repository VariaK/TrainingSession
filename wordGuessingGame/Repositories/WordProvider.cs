using Npgsql;

namespace wordGuessingGame.Repositories
{
    public class WordProvider : IWordProvider
    {
        string connectionString =
            "Host=localhost;Port=5432;Database=wordgamedb;Username=postgres;Password=root";
        NpgsqlConnection connection;

        public string GetRandomWord()
        {
            string selectQuery = "select word_text from words order by random() limit 1";
            NpgsqlCommand command = new NpgsqlCommand(selectQuery, connection);
            string word = "";
            try
            {
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    word = reader.GetString(0);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Word successfully retried from Database");
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
            return word;

        }
        public WordProvider()
        {
            connection = new NpgsqlConnection(connectionString);

        }
    }
}