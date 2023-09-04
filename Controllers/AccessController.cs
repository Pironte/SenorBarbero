using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SenorBarbero.Controllers
{
    /// <summary>
    /// Controller com objetivo de realizar testes de acesso do usuário, exemplo: regras de admin, políticas e autenticação de token pelo atributo Authorize
    /// </summary>
    [ApiController]
    [Route("[Controller]")]
    [Authorize]
    public class AccessController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Acesso permitido!");
        }
    }
}
