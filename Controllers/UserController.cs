using Microsoft.AspNetCore.Mvc;
using SenorBarbero.Data.Dtos;
using SenorBarbero.Services;

namespace SenorBarbero.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        public UserService _userService { get; set; }

        public UserController(UserService userService)
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
            await _userService.Login(loginUserDto);
            return Ok("Usuário logado");
        }
    }
}