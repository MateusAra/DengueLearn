namespace DengueLearn.Models
{
    public class QuestionModel
    {
        public long Id { get; set; }
        public string QuestionText { get; set; }
        public string Options { get; set; }
        public string SelectedOption { get; set; }
        public string CorrectOption { get; set; }
        public long QuizId { get; set; }

        public List<string> GetOptions()
        {
            return Options.Split(",").ToList();
        }
    }
}
