using BroCode.BlogTemplate.Application.Contracts;
using BroCode.BlogTemplate.DTO;
using BroCode.BlogTemplate.Model;
using BroCode.BlogTemplate.Persistence.Repositories;
using Kinvo.Utilities.Validations;
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
            this.ValidateCategoryName(categoryDTO.Name);
            _categoryRepository.Create(new Category(categoryDTO.Name));
        }

        public void Update(CategoryDTO categoryDTO)
        {
            var category = _categoryRepository.GetById(categoryDTO.Id);
            Validate.NotNull(category, "Category couldn't be found");
            this.ValidateCategoryName(categoryDTO.Name);
            if (categoryDTO.Name != category.Name)
            {
                var existingCategory = _categoryRepository.FindByName(categoryDTO.Name);
                Validate.IsTrue(existingCategory == null, "There is already a category with this name on the database");

                category.Name = categoryDTO.Name;
                _categoryRepository.Update(category);
            }
        }

        public bool Delete(int categoryId)
        {
            throw new NotImplementedException();
        }

        #region Private methods
        private void ValidateCategoryName(string name)
        {
            Validate.NotNullOrEmpty(name, "Name is required");
            Validate.LessOrEqualThan(name.Length, 70, "Name must be 70 characters or less");
        }
        #endregion
    }
}
