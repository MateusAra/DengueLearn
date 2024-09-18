using DengueLearn.Models;

namespace DengueLearn.Services.Interfaces
{
    public interface IService
    {
        UserModel AddUser(UserModel user);
        List<UserModel> GetAllUsers();
        UserModel UpdateUser(UserModel user);
        bool DeleteUser(long id);
        UserModel? GetUserById(long id);
        UserModel? UpdatePassword(UserModel user);
        UserModel? GetUserByEmail(string userName);
        bool SendEmail(string destination, string subject, string message);
        UserModel GetUserSession();
        void AddUserSession(UserModel user);
        void RemoveUserSession();
    }
}
