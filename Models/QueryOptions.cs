namespace TriviaGame.Models
{
    public class QueryOptions
    {
        public int? Amount { get; set; }
        public TriviaCategory Category { get; set; }
        public Difficulty Difficulty { get; set; }
        public bool? MultipleChoice { get; set; }

        public void Deconstruct(out int? Amount, out TriviaCategory Category, out Difficulty Difficulty, out bool? MultipleChoice)
        {
            Amount = this.Amount;
            Category = this.Category;
            Difficulty = this.Difficulty;
            MultipleChoice = this.MultipleChoice;
        }
    }
}