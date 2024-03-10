using BookAutomation.Business.Abstract;
using BookAutomation.Business.Concrete;
using BookAutomation.Business.DTOs;
using BookAutomation.Business.ROs;
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
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<BookRO>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAll()
        {
            var users = await _bookService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("genre")]
        [ProducesResponseType(typeof(BookRO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAll([FromQuery] string? genre)
        {
            var last = await _bookService.GetByGenreAsync(genre.ToString());
            return Ok(last);
        } 

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BookRO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _bookService.GetByIdAsync(id);
            return Ok(model);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(typeof(BookRO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Add([FromBody] BookDTO book)
        {
            await _bookService.CreateAsync(book);
            var newBook = await _bookService.GetByIdAsync(book.Id);
            return Ok(newBook);
        }

        [HttpPatch("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(typeof(BookRO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Update(int id, [FromBody] BookDTO book)
        {
            await _bookService.UpdateAsync(id, book);
            var updated = await _bookService.GetByIdAsync(id);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(typeof(BookRO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Delete(int id)
        {

            var deleted = await _bookService.GetByIdAsync(id);
            await _bookService.DeleteAsync(id);
            return Ok(deleted);
        }
    }
}
