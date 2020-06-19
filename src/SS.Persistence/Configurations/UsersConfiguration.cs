using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SS.Domain.Entities;

namespace SS.Persistence.Configurations
{
    public class UsersConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Id)
                .IsRequired();

            builder.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(e => e.PasswordHash)
                .IsRequired();

            builder.Property(e => e.Birthday)
                .HasConversion(new DateTimeToStringConverter());
        }
    }   
}
