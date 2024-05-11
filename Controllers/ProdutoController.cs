using API_Avaliacao_Produtos_Servicos.Data;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using API_Avaliacao_Produtos_Servicos.Services.Interfaces;
using API_Avaliacao_Produtos_Servicos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace API_Avaliacao_Produtos_Servicos.Controllers
{
    [ApiController]
    [Route(template: "api/v1")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        public ProdutoController(IProdutoService produtoService)
        {
			_produtoService = produtoService;
        }


        //[HttpGet("produto")]
        //public async Task<IEnumerable<Produto>> Get()
        //{
        //    return await _produtoService.GetAllProdutos();         
        //}


        [HttpGet("produto")]
        public async Task<IActionResult> Get()
        {
            var response = await _produtoService.GetAllProdutos();
            if(response != null)
                return Ok(response);

            return BadRequest();
        }

        [HttpGet("produto/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            //var produto = await _produtoRepository.FindById(id);
            //if (produto == null)
            //    return NotFound("Produto não encontrado!");
            //return Ok(produto);

            return null;
        }

        [HttpPost("produto")]
        public async Task<IActionResult> Post([FromBody] ProdutoViewModel produto)
        {
            var response = await _produtoService.AdicionarProduto(produto);
            if (response != null)
                return Ok(response);

            return BadRequest();
        }

        [HttpPut("produto/{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] ProdutoViewModel produto)
        {
            try
            {
                await _produtoService.AlterarProduto(id, produto);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

        }

        [HttpDelete("produto/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _produtoService.DeletarProduto(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

    }
}
