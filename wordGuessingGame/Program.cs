using Npgsql;
using wordGuessingGame.Services;
using wordGuessingGame.Repositories;
using System.Net;
using System.Reflection.Metadata;

namespace wordGuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program prgm = new Program();
            prgm.StartGame();
        }

        public void StartGame()
        {
            Console.WriteLine("-- Welcome to the game! --");
            Console.WriteLine("Enter 1 to register");
            Console.WriteLine("Enter 2 to login");
            int option = Convert.ToInt32(Console.ReadLine());
            UserRepository userRepo = new UserRepository();
            switch (option)
            {
                case 1:
                    bool registerSuccess = userRepo.Register();

                    if (registerSuccess)
                    {
                        Console.WriteLine("\nPlease login to continue.\n");

                        bool loginSuccess = userRepo.Login();

                        if (loginSuccess)
                        {
                            string username = userRepo.LoggedInUsername;

                            IWordProvider wordProvider = new WordProvider();

                            Game game = new Game(wordProvider, username);

                            game.Play();
                        }
                    }

                    break;

                case 2:
                    bool loginResult = userRepo.Login();

                    if (loginResult)
                    {
                        string username = userRepo.LoggedInUsername;

                        IWordProvider wordProvider = new WordProvider();

                        Game game = new Game(wordProvider, username);

                        game.Play();
                    }
                    else
                    {
                        Console.WriteLine("Login unsuccessful");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}