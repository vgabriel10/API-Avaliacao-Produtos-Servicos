using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Services.Interfaces;
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
        public async Task<IActionResult> Get()
        {
            var result = await _categoriaService.RetornarTodasCategorias();
            if (result != null)
                return Ok(result);

            return BadRequest();
            
        }

        [HttpGet("categoria/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _categoriaService.RetornarTodasCategorias();
                if (result != null)
                    return Ok(result);

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("categoria")]
        public async Task<IActionResult> Post(CreateCategoriaInputModel categoriaInputModel)
        {
            try
            {
                var result = _categoriaService.AdicionarCategoria(categoriaInputModel);
                if (result != null)
                    return Ok(result);

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("categoria/{id}")]
        public async Task<IActionResult> Put(
            [FromRoute] int id, 
            [FromBody] UpdateCategoriaInputModel categoriaInputModel)
        {
            try
            {
                var result = _categoriaService.EditarCategoria(id, categoriaInputModel);
                if (result != null)
                    return Ok(result);

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

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
