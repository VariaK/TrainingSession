// using wordGuessingGame.Exceptions;
using wordGuessingGame.Repositories;

namespace wordGuessingGame.Services
{
    public class Game
    {
        private readonly IWordProvider _wordProvider;
        private readonly GuessValidator _validator;
        private readonly FeedbackGenerator _feedbackGenerator;

        private readonly string _username;

        private int _score = 0;

        public Game(IWordProvider wordProvider, string username)
        {
            _wordProvider = wordProvider;
            _validator = new GuessValidator();
            _feedbackGenerator = new FeedbackGenerator();
            _username = username;
        }

        public void Play()
        {
            string hiddenWord = _wordProvider.GetRandomWord();

            List<string> previousGuesses = [];

            Console.WriteLine("\n\t===== WORDLE =====");
            Console.WriteLine("Guess the hidden 5-letter word.");
            Console.WriteLine();

            for (int attempt = 1; attempt <= 6; attempt++)
            {
                try
                {
                    Console.Write($"Attempt {attempt}/6: ");

                    string guess = Console.ReadLine()!.ToUpper();

                    _validator.Validate(guess);

                    if (previousGuesses.Contains(guess))
                    {
                        throw new InvalidGuessException("Duplicate guess is not allowed.");
                    }

                    previousGuesses.Add(guess);

                    string feedback =
                        _feedbackGenerator.Generate(hiddenWord, guess);

                    _feedbackGenerator.DisplayFeedback(guess, feedback);

                    if (guess == hiddenWord)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n Congratulations! You guessed the word!");
                        Console.ResetColor();
                        DisplayComment(attempt);

                        _score += (7 - attempt) * 10;
                        UserRepository repo = new UserRepository();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Score: {_score}");
                        Console.ResetColor();
                        repo.UpdateScore(_username, _score);
                        return;
                    }
                }
                catch (InvalidGuessException ex)
                {

                    Console.WriteLine($"Error: {ex.Message}");
                    attempt--;
                }
            }
            Console.WriteLine($"\nGame Over! The hidden word was: {hiddenWord}");
        }

        private void DisplayComment(int attempt)
        {
            switch (attempt)
            {
                case 1:
                    Console.WriteLine("Genius!");
                    break;

                case 2:
                    Console.WriteLine("Excellent!");
                    break;

                case 3:
                    Console.WriteLine("Great job!");
                    break;

                case 4:
                    Console.WriteLine("Good work!");
                    break;

                case 5:
                    Console.WriteLine("Nice try!");
                    break;

                case 6:
                    Console.WriteLine("That was close!");
                    break;
            }
        }
    }
}