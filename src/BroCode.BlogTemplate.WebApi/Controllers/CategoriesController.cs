using BroCode.BlogTemplate.Application.Contracts;
using BroCode.BlogTemplate.DTO;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        public ActionResult<IEnumerable<CategoryDTO>> GetAll()
        {
            var categories = _categoryService.GetAll();
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public ActionResult<CategoryDTO> GetById(int id)
        {
            var category = _categoryService.GetById(id);
            return Ok(category);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(201)]
        public IActionResult Create(CreateCategoryDTO categoryDTO)
        {
            _categoryService.Create(categoryDTO);
            return StatusCode(201);
        }
    }
}
