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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<UserRO>),StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserRO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _userService.GetByIdAsync(id);
            return Ok(model);
        }

        [HttpGet("lastname")]
        [ProducesResponseType(typeof(UserRO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> GetAll([FromQuery] string? lastname)
        {
            var last = await _userService.GetByLastNameAsync(lastname.ToString());
            return Ok(last);
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserRO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Add([FromBody] UserDTO users)
        {
            await _userService.CreateAsync(users);
            var newUsers = await _userService.GetByIdAsync(users.Id);
            return Ok(newUsers);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(UserRO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Update(int id, [FromBody] UserDTO users)
        {
            await _userService.UpdateAsync(id, users);
            var updated = await _userService.GetByIdAsync(id);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(UserRO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Delete(int id)
        {

            var deleted = await _userService.GetByIdAsync(id);
            await _userService.DeleteAsync(id);
            return Ok(deleted);
        }
    }
}