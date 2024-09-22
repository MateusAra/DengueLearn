using DengueLearn.Data.Map;
using DengueLearn.Models;
using Microsoft.EntityFrameworkCore;

namespace DengueLearn.Data
{
    public class DengueLearnDbContext : DbContext
    {
        public DengueLearnDbContext(DbContextOptions<DengueLearnDbContext> options) : base(options) { }

        public DbSet<UserModel> User { get; set; }
        public DbSet<VideoModel> Video { get; set; }
        public DbSet<QuestionModel> Question { get; set; }
        public DbSet<ResultQuizModel> ResultQuiz { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new VideoMap());
            modelBuilder.ApplyConfiguration(new QuestionMap());
            modelBuilder.ApplyConfiguration(new ResultQuizMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
