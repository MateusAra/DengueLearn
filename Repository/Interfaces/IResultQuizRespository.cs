using DengueLearn.Models;

namespace DengueLearn.Repository.Interfaces
{
    public interface IResultQuizRespository
    {
        ResultQuizModel AddResult(ResultQuizModel resultQuiz);
        List<ResultQuizModel> GetAllResults();
    }
}
