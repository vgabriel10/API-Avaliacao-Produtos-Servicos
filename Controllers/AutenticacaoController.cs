using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_Avaliacao_Produtos_Servicos.Controllers
{
    [ApiController]
    [Route(template: "api/v1")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AutenticacaoController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("GerarToken")]
        public async Task<IActionResult> GerarToken([FromBody] UsuarioLogin usuarioLogin)
        {
            try
            {
                var token = _tokenService.GerarToken(usuarioLogin);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            
        }
    }
}
