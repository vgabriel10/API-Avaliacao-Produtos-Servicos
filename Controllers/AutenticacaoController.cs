using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_Avaliacao_Produtos_Servicos.Controllers
{
    [ApiController]
    [Route(template: "api/v1")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IAutenticacaoService _autenticacaoService;

        public AutenticacaoController(ITokenService tokenService, IAutenticacaoService autenticacaoService)
        {
            _tokenService = tokenService;
            _autenticacaoService = autenticacaoService;
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

        [HttpPost("CriarConta")]
        public async Task<IActionResult> CriarContaUsuario([FromBody] CreateUsuarioLoginInputModel usuarioLogin)
        {
            try
            {
                var result = await _autenticacaoService.CadastrarUsuario(usuarioLogin);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
