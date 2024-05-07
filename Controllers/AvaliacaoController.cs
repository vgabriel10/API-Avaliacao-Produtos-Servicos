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


        [HttpGet("avaliacao")]
        public async Task<IEnumerable<Produto>> GetAllAvaliacoesProdutos()
        {
            return await _produtoRepository.FindAll();         
        }


        [HttpGet("avaliacao/{id}")]
        public async Task<IActionResult> GetByIdAvaliacoesProdutos([FromRoute] int id)
        {
            var produto = await _produtoRepository.FindById(id);
            if (produto == null)
                return NotFound("Produto não encontrado!");
            return Ok(produto);
        }

        [HttpPost("avaliacao")]
        public async Task<IActionResult> PostProduto([FromBody] Produto produto)
        {
            return Ok("Deu bom!");
        }

        [HttpPut("avaliacao/{id}")]
        public async Task<IActionResult> PutProduto([FromRoute] int id, [FromBody] Produto produto)
        {
            return null;
        }

        [HttpDelete("avaliacao/{id}")]
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
