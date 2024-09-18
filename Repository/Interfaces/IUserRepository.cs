using DengueLearn.Models;

namespace DengueLearn.Repository.Interfaces
{
    public interface IUserRepository
    {
        UserModel AddUser(UserModel user);
        List<UserModel> GetAllUsers();
        UserModel UpdateUser(UserModel user);
        bool DeleteUser(UserModel user);
        UserModel? GetUserById(long id);
        UserModel? GetUserByEmail(string userName);
    }
}
