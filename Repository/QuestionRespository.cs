using DengueLearn.Data;
using DengueLearn.Models;
using DengueLearn.Repository.Interfaces;

namespace DengueLearn.Repository
{
    public class QuestionRespository : IQuestionRepository
    {
        private readonly DengueLearnDbContext _dbContext;

        public QuestionRespository(DengueLearnDbContext context)
        {
            _dbContext = context;
        }

        public List<QuestionModel> GetAllQuestions()
        {
            return _dbContext.Question.ToList();
        }
    }
}
