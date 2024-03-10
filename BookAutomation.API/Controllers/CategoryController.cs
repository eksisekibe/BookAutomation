using BookAutomation.Business.Abstract;
using BookAutomation.Business.Concrete;
using BookAutomation.Business.DTOs;
using BookAutomation.Business.ROs;
using BookAutomation.Entity.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookAutomation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CategoryRO>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAll()
        {
            var users = await _categoryService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CategoryRO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _categoryService.GetByIdAsync(id);
            return Ok(model);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(typeof(CategoryRO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Add([FromBody] CategoryDTO category)
        {
            await _categoryService.CreateAsync(category);
            var newCategory = await _categoryService.GetByIdAsync(category.Id);
            return Ok(newCategory);
        }

        [HttpPatch("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(typeof(CategoryRO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Update(int id, [FromBody] CategoryDTO category)
        {
            await _categoryService.UpdateAsync(id, category);
            var updated = await _categoryService.GetByIdAsync(id);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(typeof(CategoryRO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Delete(int id)
        {

            var deleted = await _categoryService.GetByIdAsync(id);
            await _categoryService.DeleteAsync(id);
            return Ok(deleted);
        }
    }
}
