namespace wordGuessingGame.Repositories
{
    public class WordProvider:IWordProvider
    {
        private List<string> words = ["APPLE","MANGO","GRAPE","TRAIN","PLANT","BRAIN"];

        private Random random = new();

        public string GetRandomWord()
        {
            int index = random.Next(words.Count);
            return words[index];
        }
    }
}