using BroCode.BlogTemplate.Model;
using System.Collections.Generic;

namespace BroCode.BlogTemplate.Persistence.Repositories
{
    public interface ICategoryRepository
    {
        Category FindByName(string name);
        IEnumerable<Category> GetAll();
        Category GetById(int id);

        void Create(Category category);
        void Update(Category category);
    }
}
