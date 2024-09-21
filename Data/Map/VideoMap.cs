using DengueLearn.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DengueLearn.Data.Map
{
    public class VideoMap : IEntityTypeConfiguration<VideoModel>
    {
        public void Configure(EntityTypeBuilder<VideoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title);
            builder.Property(x => x.Description);
            builder.Property(x => x.Iframe);
        }
    }
}
