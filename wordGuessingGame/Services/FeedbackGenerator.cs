namespace wordGuessingGame.Services
{
    public class FeedbackGenerator
    {
        public string Generate(string hiddenWord, string guess)
        {
            char[] feedback = new char[5];

            for (int i = 0; i < 5; i++)
            {
                if (guess[i] == hiddenWord[i])
                {
                    feedback[i] = 'G';
                }
                else if (hiddenWord.Contains(guess[i]))
                {
                    feedback[i] = 'Y';
                }
                else
                {
                    feedback[i] = 'X';
                }
            }

            return new string(feedback);
        }

        public void DisplayFeedback(string guess, string feedback)
        {
            for (int i = 0; i < guess.Length; i++)
                Console.Write($"{guess[i]} ");

            Console.ResetColor();
            Console.WriteLine();

            for (int i = 0; i < feedback.Length; i++)
            {

                Console.Write($"{feedback[i]} ");
            }

            Console.WriteLine("\n");
        }
    }
}