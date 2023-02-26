using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserService.Domain.Entities;

namespace UserService.Domain.Settings
{
    public class UserSettings : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(user => user.Id);

            builder.Property(user => user.Name).IsRequired();
            builder.HasIndex(user => user.Username).IsUnique();
            builder.HasIndex(user => user.Email).IsUnique();
            builder.Property(user => user.Password).IsRequired();
            builder.Property(user => user.IsAdmin).IsRequired();
            builder.Property(user => user.UserType).HasConversion<int>().IsRequired();
            builder.Property(user => user.CreatedOn).IsRequired().HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
