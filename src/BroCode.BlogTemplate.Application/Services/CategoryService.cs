using BroCode.BlogTemplate.Application.Contracts;
using BroCode.BlogTemplate.DTO;
using BroCode.BlogTemplate.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BroCode.BlogTemplate.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            var categories = _categoryRepository.GetAll();
            var categoriesDTO = categories.Select(category => new CategoryDTO(category.Id, category.Name));
            
            return categoriesDTO;
        }

        public CategoryDTO GetById(int id)
        {
            var category = _categoryRepository.GetById(id);
            return new CategoryDTO(category.Id, category.Name);
        }

        public void Create(CreateCategoryDTO categoryDTO)
        {
            throw new NotImplementedException();
        }

        public void Update(CategoryDTO categoryDTO)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
