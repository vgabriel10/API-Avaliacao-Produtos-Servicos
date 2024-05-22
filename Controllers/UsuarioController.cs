using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using API_Avaliacao_Produtos_Servicos.Services.Interfaces;
using API_Avaliacao_Produtos_Servicos.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API_Avaliacao_Produtos_Servicos.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("usuario")]
        public async Task<IEnumerable<Usuario>> Get()
        {
            return await _usuarioService.RetornarTodosUsuarios();
        }

        [HttpGet("usuario/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return null;
        }

        [HttpPost("usuario/")]
        public async Task<IActionResult> Post(UsuarioViewModel usuario)
        {
            var result = _usuarioService.AdicionarUsuario(usuario)
        }

        [HttpPut("usuario/{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UsuarioViewModel usuario)
        {
            var result = await _usuarioService.EditarUsuario(id, usuario);

            if (result != null)
                return Ok(result);

            return BadRequest();
        }

        [HttpDelete("usuario/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _usuarioService.DeletarUsuario(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
