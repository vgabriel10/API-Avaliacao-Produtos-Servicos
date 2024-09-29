using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.Response;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;
using API_Avaliacao_Produtos_Servicos.Services;
using API_Avaliacao_Produtos_Servicos.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Avaliacao_Produtos_Servicos.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController (ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet("categoria")]
        public async Task<IActionResult> Get([FromQuery] int pagina = 1, [FromQuery] int itensPagina = 20)
        {
            var result = await _categoriaService.RetornarTodasCategorias(pagina, itensPagina);
            if (result == null)
                return BadRequest();

            int totalItens = await _categoriaService.QuantidadeCategoriasAtivas();
            int totalPaginas = await _categoriaService.QuantidadePaginas(totalItens, itensPagina);

            return Ok( new ApiResponse<CategoriaViewModel>
            {
                PaginaAtual = pagina,
                ItensPagina = result.Count(),
                TotalPaginas = totalPaginas,
                TotalItens = totalItens,
                Data = result,
                Success = true,
            });                        
        }

        [HttpGet("categoria/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _categoriaService.RetornarCategoriaPorId(id);
                if (result != null)
                    return Ok(result);

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Admin")]
        [HttpPost("categoria")]
        public async Task<IActionResult> Post(CreateCategoriaInputModel categoriaInputModel)
        {
            try
            {
                var result = await _categoriaService.AdicionarCategoria(categoriaInputModel);
                if (result != null)
                    return Ok(result);

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Admin")]
        [HttpPut("categoria/{id}")]
        public async Task<IActionResult> Put(
            [FromRoute] int id, 
            [FromBody] UpdateCategoriaInputModel categoriaInputModel)
        {
            try
            {
                var result = await _categoriaService.EditarCategoria(id, categoriaInputModel);
                if (result != null)
                    return Ok(result);

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Admin")]
        [HttpDelete("categoria/{id}")]
        public async Task<IActionResult> Delete( [FromRoute] int id)
        {
            try
            {
                await _categoriaService.DeletarCategoria(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
