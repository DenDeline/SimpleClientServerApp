using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SS.Domain.Entities;

namespace SS.DAL.SqlServer.Configurations
{
    public class PostConfiguration: IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Created)
                .HasConversion(new DateTimeToStringConverter());

            builder.Property(e => e.LastModified)
                .HasConversion(new DateTimeToStringConverter());

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.CreatorId);

        }
    }
}
