using BroCode.BlogTemplate.Application.Contracts;
using BroCode.BlogTemplate.DTO;
using Kinvo.Utilities.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [ProducesResponseType(400)]
        public IActionResult Create(CreateCategoryDTO createCategoryDTO)
        {
            try
            {
                _categoryService.Create(createCategoryDTO);
                return StatusCode(201);
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [HttpPut]
        [Authorize(Roles = "admin")]
        [Route("{id}")]
        public IActionResult Update(int id, CategoryDTO categoryDTO)
        {
            try
            {
                categoryDTO.Id = id;
                _categoryService.Update(categoryDTO);
                return NoContent();
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [HttpDelete]
        [Authorize(Roles = "admin")]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _categoryService.Delete(id);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }
    }
}
