using BroCode.BlogTemplate.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BroCode.BlogTemplate.Persistence.Configs
{
    public class ArticleConfig : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                .HasMaxLength(100)
                .IsRequired();
            
            builder.Property(b => b.Content)
                .IsRequired();
            
            builder.Property(b => b.CreatedAt)
                .IsRequired();

            builder.Property(b => b.UpdatedAt)
                .IsRequired();

            builder.Property(b => b.IsPublished)
                .IsRequired()
                .HasDefaultValue(false);

            //Relations
            builder.HasOne(b => b.User)
                .WithMany(b => b.Articles)
                .HasForeignKey(b => b.UserId);
        }
    }
}
