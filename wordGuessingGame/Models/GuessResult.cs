namespace wordGuessingGame.Models
{
    public class GuessResult
    {
        public string Guess { get; set; } = string.Empty;

        public string Feedback { get; set; } = string.Empty;

        public bool IsCorrect { get; set; }
    }
}