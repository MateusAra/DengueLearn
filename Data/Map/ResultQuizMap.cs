using DengueLearn.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DengueLearn.Data.Map
{
    public class ResultQuizMap : IEntityTypeConfiguration<ResultQuizModel>
    {
        public void Configure(EntityTypeBuilder<ResultQuizModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Passed);
            builder.Property(x => x.UserId);
            builder.Property(x => x.QuizId);
        }
    }
}
