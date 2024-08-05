using API_Avaliacao_Produtos_Servicos.Data;
using API_Avaliacao_Produtos_Servicos.Exceptions;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using API_Avaliacao_Produtos_Servicos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace API_Avaliacao_Produtos_Servicos.Controllers
{
    [ApiController]
    [Route(template: "api/v1")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IFornecedorService _fornecedorService;
        private readonly ICategoriaService _categoriaService;

        public ProdutoController(IProdutoService produtoService, IFornecedorService fornecedorService, ICategoriaService categoriaService)
        {
			_produtoService = produtoService;
            _fornecedorService = fornecedorService;
            _categoriaService = categoriaService;
        }

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
            var response = await _produtoService.RetornarProdutoPorId(id);
            if (response != null)
                return Ok(response);

            return NotFound();
        }

        [HttpPost("produto")]
        public async Task<IActionResult> Post([FromBody] CreateProdutoInputModel produto)
        {
            var existeFornecedor = await _fornecedorService.RetornarFornecedorPorId(produto.FornecedorId);
            var existeCategoria = await _categoriaService.RetornarCategoriaPorId(produto.CategoriaId);
            if (existeFornecedor == null)
                throw new NotFoundException("Fornecedor não encontrado");
            if (existeCategoria == null)
                throw new NotFoundException("Categoria não encontrada");
            var response = await _produtoService.AdicionarProduto(produto);
            if (response != null)
                return Ok(response);

            return BadRequest();
        }

        [HttpPut("produto/{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UpdateProdutoInputModel produto)
        {
            try
            {
                var existeFornecedor = await _fornecedorService.RetornarFornecedorPorId(produto.FornecedorId);
                var existeCategoria = await _categoriaService.RetornarCategoriaPorId(produto.CategoriaId);
                if (existeFornecedor == null)
                    throw new NotFoundException("Fornecedor não encontrado");
                if (existeCategoria == null)
                    throw new NotFoundException("Categoria não encontrada");
                var result = await _produtoService.AlterarProduto(id,produto);
                return Ok(result);
            }
            catch (Exception ex)
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
