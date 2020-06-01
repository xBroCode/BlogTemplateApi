using BroCode.BlogTemplate.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BroCode.BlogTemplate.Persistence.Configs
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .HasMaxLength(50)
                .IsRequired();
            
            builder.Property(b => b.Email)
                .HasMaxLength(150);
            
            builder.Property(b => b.Content)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(b => b.Website)
                .HasMaxLength(70);

            builder.Property(b => b.CreatedAt)
                .IsRequired();

            builder.Ignore(b => b.UpdatedAt);
        }
    }
}
