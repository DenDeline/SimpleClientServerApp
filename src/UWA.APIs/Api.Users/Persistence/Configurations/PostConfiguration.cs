using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Persistence.Configurations
{
    public class PostConfiguration: IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Created)
                .HasConversion<DateTimeToStringConverter>();

            builder.Property(e => e.LastModified)
                .HasConversion<DateTimeToStringConverter>();

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.CreatorId);

        }
    }
}
