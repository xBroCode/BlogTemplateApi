using BroCode.BlogTemplate.Application.Contracts;
using BroCode.BlogTemplate.DTO;
using BroCode.BlogTemplate.Persistence.Repositories;
using System;
using System.Collections.Generic;

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
            var categoriesDTO = new List<CategoryDTO>();
            foreach (var category in categories)
                categoriesDTO.Add(new CategoryDTO { Id = category.Id, Name = category.Name });

            return categoriesDTO;
        }

        public CategoryDTO GetById(int id)
        {
            throw new NotImplementedException();
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
