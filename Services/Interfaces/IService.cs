using DengueLearn.Models;

namespace DengueLearn.Services.Interfaces
{
    public interface IService
    {
        UserModel AddUser(UserModel user);
        UserModel UpdateUser(UserModel user);
        UserModel? GetUserById(long id);
        UserModel? UpdatePassword(UserModel user);
        UserModel? GetUserByEmail(string userName);
        bool SendEmail(string destination, string subject, string message);
        UserModel GetUserSession();
        void AddUserSession(UserModel user);
        void RemoveUserSession();
        VideoModel GetVideoById(long id);
        List<QuestionModel> GetAllQuestions();
        ResultQuizModel AddResult(ResultQuizModel resultQuiz);
        List<ResultQuizModel> GetAllResults();
    }
}
