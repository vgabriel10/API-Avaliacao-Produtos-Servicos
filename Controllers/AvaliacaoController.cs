using API_Avaliacao_Produtos_Servicos.Data;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace API_Avaliacao_Produtos_Servicos.Controllers
{
    [ApiController]
    [Route(template: "api/v1")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        public AvaliacaoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }


        [HttpGet("produto")]
        public async Task<IEnumerable<Produto>> GetAllAvaliacoesProdutos()
        {
            return await _produtoRepository.FindAll();         
        }


        [HttpGet("produto/{id}")]
        public async Task<IActionResult> GetByIdAvaliacoesProdutos([FromRoute] int id)
        {
            var produto = await _produtoRepository.FindById(id);
            if (produto == null)
                return NotFound("Produto não encontrado!");
            return Ok(produto);
        }

        [HttpPost("produto")]
        public async Task<IActionResult> PostProduto([FromBody] Produto produto)
        {
            return Ok("Deu bom!");
        }

        [HttpPut("produto/{id}")]
        public async Task<IActionResult> PutProduto([FromRoute] int id, [FromBody] Produto produto)
        {
            return null;
        }

        [HttpDelete("produto/{id}")]
        public async Task<IActionResult> DeleteProduto([FromRoute] int id)
        {
            try
            {
                //Task<IActionResult> produto = await _produtoRepository.DeleteById(id);
                await _produtoRepository.DeleteById(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

    }
}
