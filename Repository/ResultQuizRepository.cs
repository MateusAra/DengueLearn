using DengueLearn.Data;
using DengueLearn.Models;
using DengueLearn.Repository.Interfaces;

namespace DengueLearn.Repository
{
    public class ResultQuizRepository : IResultQuizRespository
    {
        private readonly DengueLearnDbContext _dbContext;

        public ResultQuizRepository(DengueLearnDbContext context)
        {
            _dbContext = context;
        }

        public ResultQuizModel AddResult(ResultQuizModel resultQuiz)
        {
            _dbContext.ResultQuiz.Add(resultQuiz);
            _dbContext.SaveChanges();

            return resultQuiz;
        }

        public List<ResultQuizModel> GetAllResults()
        {
            return _dbContext.ResultQuiz.ToList();
        }
    }
}
