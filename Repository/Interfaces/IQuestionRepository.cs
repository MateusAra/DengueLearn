using DengueLearn.Models;

namespace DengueLearn.Repository.Interfaces
{
    public interface IQuestionRepository
    {
        List<QuestionModel> GetAllQuestions();
    }
}
