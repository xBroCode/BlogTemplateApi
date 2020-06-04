using BroCode.BlogTemplate.Model;
using BroCode.BlogTemplate.Persistence.Contexts;
using System.Linq;

namespace BroCode.BlogTemplate.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext context)
            : base(context)
        {
        }

        public Category FindByName(string name)
        {
            return this.dbSet.FirstOrDefault(category => category.Name == name);
        }
    }
}
