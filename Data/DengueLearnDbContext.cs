using DengueLearn.Data.Map;
using DengueLearn.Models;
using Microsoft.EntityFrameworkCore;

namespace DengueLearn.Data
{
    public class DengueLearnDbContext : DbContext
    {
        public DengueLearnDbContext(DbContextOptions<DengueLearnDbContext> options) : base(options) { }

        public DbSet<UserModel> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
