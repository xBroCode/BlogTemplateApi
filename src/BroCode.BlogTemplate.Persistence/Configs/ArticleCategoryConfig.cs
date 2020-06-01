using BroCode.BlogTemplate.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BroCode.BlogTemplate.Persistence.Configs
{
    public class ArticleCategoryConfig : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.ToTable("ArticleCategories");
            builder.HasKey(b => new { b.ArticleId, b.CategoryId });

            builder.HasOne(b => b.Article)
                .WithMany(b => b.ArticleCategories)
                .HasForeignKey(b => b.ArticleId);

            builder.HasOne(b => b.Category)
                .WithMany(b => b.ArticleCategories)
                .HasForeignKey(b => b.CategoryId);
        }
    }
}
