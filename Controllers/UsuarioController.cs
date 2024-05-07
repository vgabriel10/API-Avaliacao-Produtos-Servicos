using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_Avaliacao_Produtos_Servicos.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuario)
        {
            _usuarioRepository = usuario;
        }

        [HttpGet("usuario")]
        public async Task<IEnumerable<Usuario>> Get()
        {
            return await _usuarioRepository.BuscarTodosUsuarios();
        }

        [HttpGet("usuario/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return null;
        }

        [HttpPost("usuario/")]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            return Ok(usuario);
        }
    }
}
