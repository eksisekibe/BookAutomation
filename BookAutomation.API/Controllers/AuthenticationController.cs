using BookAutomation.Business.Abstract;
using BookAutomation.Business.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookAutomation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthenticationController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var loginRO = await _authorizationService.Login(loginDTO);
            return Ok(loginRO);
        }
    }
}
