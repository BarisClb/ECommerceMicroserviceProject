using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserService.Domain.Entities;

namespace UserService.Domain.Settings
{
    public class AddressSettings : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses").HasKey(address => address.Id);

            builder.Property(address => address.Name).IsRequired();
            builder.Property(address => address.AddressLine).IsRequired();
            builder.Property(address => address.District).IsRequired();
            builder.Property(address => address.City).IsRequired();
            builder.Property(address => address.PostalCode).IsRequired();
            builder.Property(address => address.CreatedOn).IsRequired().HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(address => address.User).WithMany(user => user.Addresses).HasForeignKey(address => address.UserId).HasPrincipalKey(user => user.Id);
        }
    }
}
