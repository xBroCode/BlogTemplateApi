using BroCode.BlogTemplate.Model;
using System.Collections.Generic;

namespace BroCode.BlogTemplate.Persistence.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
    }
}
