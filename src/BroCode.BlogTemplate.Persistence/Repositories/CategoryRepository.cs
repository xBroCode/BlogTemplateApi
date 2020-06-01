using BroCode.BlogTemplate.Model;
using BroCode.BlogTemplate.Persistence.Contexts;

namespace BroCode.BlogTemplate.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext context)
            : base(context)
        {
        }
    }
}
