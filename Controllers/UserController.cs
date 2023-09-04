using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SenorBarbero.Data.Dtos;
using SenorBarbero.IServices;

namespace SenorBarbero.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        public IUserService _userService { get; set; }

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(CreateUserDto createUserDto)
        {
            await _userService.Register(createUserDto);
            return Ok("Usuário cadastrado com sucesso!");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            var token = await _userService.Login(loginUserDto);
            return Ok(token);
        }

        [HttpPost("LogOut")]
        [Authorize]
        public IActionResult LogOut()
        {
            _userService.LogOut();
            return Ok();
        }
    }
}