namespace BroCode.BlogTemplate.Model
{
    public class ArticleCategory
    {
        #region Constructors
        public ArticleCategory(int articleId, int categoryId)
        {
            this.ArticleId = articleId;
            this.CategoryId = categoryId;
        }

        protected ArticleCategory()
        {

        }
        #endregion

        #region Properties
        public Article Article { get; set; }
        public int ArticleId { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
        #endregion
    }
}
