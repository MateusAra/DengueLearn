using DengueLearn.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DengueLearn.Data.Map
{
    public class QuestionMap : IEntityTypeConfiguration<QuestionModel>
    {
        public void Configure(EntityTypeBuilder<QuestionModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Options);
            builder.Property(x => x.SelectedOption).IsRequired(false);
            builder.Property(x => x.CorrectOption);
            builder.Property(x => x.QuestionText);
            builder.Property(x => x.QuizId);
        }
    }
}
