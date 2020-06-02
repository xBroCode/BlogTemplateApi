using BroCode.BlogTemplate.Application.Contracts;
using BroCode.BlogTemplate.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BroCode.BlogTemplate.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDTO>> GetAll()
        {
            var categories = _categoryService.GetAll();
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<CategoryDTO> GetById(int id)
        {
            var category = _categoryService.GetById(id);
            return Ok(category);
        }
    }
}
