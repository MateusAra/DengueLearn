namespace DengueLearn.Models
{
    public class ResultQuizModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long QuizId { get; set; }
        public bool Passed { get; set; }
    }
}
