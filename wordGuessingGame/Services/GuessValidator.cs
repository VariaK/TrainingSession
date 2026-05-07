
namespace wordGuessingGame
{

    public class GuessValidator 
    {
        public void Validate(string guess)
        {
            if (string.IsNullOrEmpty(guess))
            {
                throw new InvalidGuessException("guess cannot be empty!");
            }
            if (guess.Length != 5)
            {
                throw new InvalidGuessException("the Word is not of 5 letters");
            }
            if (!guess.All(char.IsLetter))
            {
                throw new InvalidGuessException("The word should only contain letters");
            }

        }
    }
}