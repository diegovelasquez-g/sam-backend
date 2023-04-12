using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAM.Application.DTOS.Request;
using SAM.Application.Interfaces;

namespace SAM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApplication _userApplication;

        public UserController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        [AllowAnonymous]
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] UserRequestDTO userRequestDTO)
        {
            var response = await _userApplication.CreateUser(userRequestDTO);
            return Ok(response);

        }

        [AllowAnonymous]
        [HttpPost("Token")]
        public async Task<IActionResult> Token([FromBody] TokenRequestDTO tokenRequestDTO)
        {
            var response = await _userApplication.GenerateToken(tokenRequestDTO);
            return Ok(response);

        }
    }
}
