using BroCode.BlogTemplate.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BroCode.BlogTemplate.Persistence.Configs
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .HasMaxLength(70)
                .IsRequired();
        }
    }
}
