using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.Response;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using API_Avaliacao_Produtos_Servicos.Services.Interfaces;
using API_Avaliacao_Produtos_Servicos.Validators;
using FluentValidation;
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

        //[HttpGet("usuario")]
        //public async Task<IEnumerable<UsuarioViewModel>> Get([FromQuery] int pagina = 1, [FromQuery] int itensPagina = 20)
        //{
        //    //return await _usuarioService.RetornarTodosUsuarios(numeroPagina,itensPagina);
        //    var usuarios = await _usuarioService.RetornarTodosUsuarios(pagina, itensPagina);

        //    return new ApiResponse
        //    {
        //        PaginaAtual = pagina,
        //        ItensPagina = itensPagina,
        //        TotalItens = _usuarioService.QuantidadeUsuariosAtivos()

        //    };
        //}

        [HttpGet("usuario")]
        public async Task<ApiResponse<UsuarioViewModel>> Get([FromQuery] int pagina = 1, [FromQuery] int itensPagina = 20)
        {
            //return await _usuarioService.RetornarTodosUsuarios(numeroPagina,itensPagina);
            var usuarios = await _usuarioService.RetornarTodosUsuarios(pagina, itensPagina);
            int totalItens = await _usuarioService.QuantidadeUsuariosAtivos();
            int totalPaginas = await _usuarioService.QuantidadePaginas(totalItens,itensPagina);

            return new ApiResponse<UsuarioViewModel>
            {
                PaginaAtual = pagina,
                ItensPagina = usuarios.Count(),
                TotalPaginas = totalPaginas,
                TotalItens = totalItens,
                Data = usuarios,
                Success = true,                
            };
        }

        [HttpGet("usuario/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _usuarioService.BuscarUsuarioPorId(id);
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        [HttpPost("usuario/")]
        public async Task<IActionResult> Post(CreateUsuarioInputModel usuario)
        {
            var result = await _usuarioService.AdicionarUsuario(usuario);
            if (result != null)
                return Ok(result);

            return BadRequest();
        }

        [HttpPut("usuario/{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UpdateUsuarioInputModel usuario)
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
