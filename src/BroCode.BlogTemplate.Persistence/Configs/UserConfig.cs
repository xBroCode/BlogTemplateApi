using BroCode.BlogTemplate.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BroCode.BlogTemplate.Persistence.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(b => b.Email)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(b => b.Password)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(b => b.IsAdmin)
                .HasDefaultValue(false)
                .IsRequired();
        }
    }
}
