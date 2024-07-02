using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace API_Avaliacao_Produtos_Servicos.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class CategoriaController : Controller
    {
        [HttpGet("categoria")]
        public async Task<IActionResult> Get()
        {
            return View();
        }

        [HttpGet("categoria/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("categoria")]
        public async Task<IActionResult> Post(CreateCategoriaInputModel categoriaInputModel)
        {
            throw new NotImplementedException();
        }

        [HttpPut("categoria/{id}")]
        public async Task<IActionResult> Put(
            [FromRoute] int id, 
            [FromBody] UpdateCategoriaInputModel categoriaInputModel)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("categoria/{id}")]
        public async Task<IActionResult> Delete( [FromRoute] int id)
        {
            throw new NotImplementedException();
        }
    }
}
