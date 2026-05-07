namespace wordGuessingGame.Models
{
    public class GameResult
    {
        public bool Won { get; set; }

        public int AttemptsUsed { get; set; }

        public int Score { get; set; }

        public string HiddenWord { get; set; } = string.Empty;
    }
}