using DengueLearn.Data;
using DengueLearn.Models;
using DengueLearn.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DengueLearn.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DengueLearnDbContext _dbContext;

        public UserRepository(DengueLearnDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserModel AddUser(UserModel user)
        {
            _dbContext.User.Add(user);
            _dbContext.SaveChanges();

            return user;
        }

        public bool DeleteUser(UserModel user)
        {
            try
            {
                user.DeletedDate = DateTime.Now;

                _dbContext.User.Update(user);
                _dbContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<UserModel> GetAllUsers()
        {
            var users = _dbContext.User.ToList();
            //.FromSql($"SELECT * FROM dbo.[User] WHERE DeletedDate IS NULL").ToList();

            return users.Where(x => x.DeletedDate != null).ToList();
        }

        public UserModel? GetUserById(long id)
        {
            var users = _dbContext.User
                .FirstOrDefault(x => x.Id == id);

            return users;
        }

        public UserModel? GetUserByEmail(string email)
        {
            var user = _dbContext.User
                .FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper());

            return user;
        }

        public UserModel UpdateUser(UserModel user)
        {
            _dbContext.User.Update(user);
            _dbContext.SaveChanges();

            return user;
        }
    }
}
