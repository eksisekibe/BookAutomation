using BookAutomation.Business.Abstract;
using BookAutomation.Business.Concrete;
using BookAutomation.Business.DTOs;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult> GetAll()
        {
            var users = await _bookService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("genre")]
        public async Task<ActionResult> GetAll([FromQuery] string? genre)
        {
            var last = await _bookService.GetByGenreAsync(genre.ToString());
            return Ok(last);
        } 

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _bookService.GetByIdAsync(id);
            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] BookDTO book)
        {
            await _bookService.CreateAsync(book);
            var newBook = await _bookService.GetByIdAsync(book.Id);
            return Ok(newBook);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] BookDTO book)
        {
            await _bookService.UpdateAsync(id, book);
            var updated = await _bookService.GetByIdAsync(id);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            var deleted = await _bookService.GetByIdAsync(id);
            await _bookService.DeleteAsync(id);
            return Ok(deleted);
        }
    }
}
