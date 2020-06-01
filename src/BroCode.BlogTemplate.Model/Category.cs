using System.Collections.Generic;

namespace BroCode.BlogTemplate.Model
{
    public class Category
    {
        #region Constructors
        public Category(string name)
        {
            this.Name = name;
        }

        protected Category()
        {

        }
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ArticleCategory> ArticleCategories { get; set; }
        #endregion
    }
}
