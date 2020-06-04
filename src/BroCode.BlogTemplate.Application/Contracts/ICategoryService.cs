using BroCode.BlogTemplate.DTO;
using System.Collections.Generic;

namespace BroCode.BlogTemplate.Application.Contracts
{
    public interface ICategoryService
    {
        void Create(CreateCategoryDTO categoryDTO);
        void Update(CategoryDTO categoryDTO);
        void Delete(int categoryId);
        IEnumerable<CategoryDTO> GetAll();
        CategoryDTO GetById(int id);
    }
}
