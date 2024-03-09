using BookAutomation.Business.Abstract;
using BookAutomation.Business.Concrete;
using BookAutomation.Business.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookAutomation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _userService.GetByIdAsync(id);
            return Ok(model);
        }

        [HttpGet("lastname")]
        public async Task<ActionResult> GetAll([FromQuery] string? lastname)
        {
            var last = await _userService.GetByLastNameAsync(lastname.ToString());
            return Ok(last);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] UserDTO users)
        {
            await _userService.CreateAsync(users);
            var newUsers = await _userService.GetByIdAsync(users.Id);
            return Ok(newUsers);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UserDTO users)
        {
            await _userService.UpdateAsync(id, users);
            var updated = await _userService.GetByIdAsync(id);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            var deleted = await _userService.GetByIdAsync(id);
            await _userService.DeleteAsync(id);
            return Ok(deleted);
        }
    }
}