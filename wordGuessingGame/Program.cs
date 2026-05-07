
using wordGuessingGame.Services;
using wordGuessingGame.Repositories;

namespace wordGuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWordProvider wordProvider = new WordProvider();
            Game game = new Game(wordProvider);

            game.Play();

            Console.WriteLine("\nThank you for playing!");
        }
    }
}