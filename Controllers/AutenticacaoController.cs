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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginInputModel usuarioLogin)
        {
            try
            {
                var usuario = await _autenticacaoService.RetornarUsuarioLoginComRolesPorLogin(usuarioLogin);
                if (usuario == null)
                    return Unauthorized("Usuário ou senha ínvalidos!");

                var token = _tokenService.GerarToken(usuario);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            
        }

        [HttpPost("criar-conta")]
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
