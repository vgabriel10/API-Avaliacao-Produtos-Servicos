using API_Avaliacao_Produtos_Servicos.Data;
using API_Avaliacao_Produtos_Servicos.Exceptions;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.Response;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using API_Avaliacao_Produtos_Servicos.Services;
using API_Avaliacao_Produtos_Servicos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace API_Avaliacao_Produtos_Servicos.Controllers
{
    [ApiController]
    [Route(template: "api/v1")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoService _avaliacaoService;
        private readonly IUsuarioService _usuarioService;
        private readonly IProdutoService _produtoService;
        public AvaliacaoController(IAvaliacaoService avaliacaoService, 
            IUsuarioService usuarioService,
            IProdutoService produtoService)
        {
            _avaliacaoService = avaliacaoService;
            _usuarioService = usuarioService;
            _produtoService = produtoService;
        }

        [HttpGet("avaliacao")]
        public async Task<IActionResult> Get([FromQuery] int pagina = 1, [FromQuery] int itensPagina = 20)
        {
            var todasAvaliacoes = await _avaliacaoService.RetornaTodasAvaliacoes(pagina,itensPagina);
            if (todasAvaliacoes == null)
                return BadRequest();

            int totalItens = await _avaliacaoService.QuantidadeAvaliacoesAtivas();
            int totalPaginas = await _avaliacaoService.QuantidadePaginas(totalItens, itensPagina);
            return Ok(new ApiResponse<AvaliacaoViewModel>
            {
                PaginaAtual = pagina,
                ItensPagina = todasAvaliacoes.Count(),
                TotalPaginas = totalPaginas,
                TotalItens = totalItens,
                Data = todasAvaliacoes,
                Success = true,
            });
        }

        [HttpGet("avaliacao/{idProduto}")]
        public async Task<IActionResult> Get([FromRoute] int idProduto, [FromQuery] int pagina = 1, [FromQuery] int itensPagina = 20)
        {
            var avaliacoesDoProduto = await _avaliacaoService.RetornaAvaliacoesDoProduto(idProduto, pagina , itensPagina);
            if (avaliacoesDoProduto == null)
                return NotFound();

            int totalItens = await _avaliacaoService.QuantidadeAvaliacoesDoProduto(idProduto);
            int totalPaginas = await _avaliacaoService.QuantidadePaginas(totalItens, itensPagina);

            return Ok(new ApiResponse<AvaliacaoViewModel>
            {
                PaginaAtual = pagina,
                ItensPagina = avaliacoesDoProduto.Count(),
                TotalPaginas = totalPaginas,
                TotalItens = totalItens,
                Data = avaliacoesDoProduto,
                Success = true,
            });

            
        }

        [HttpPost("avaliacao")]
        public async Task<IActionResult> Post(CreateAvaliacaoInputModel avaliacao)
        {
            var usuario = await _usuarioService.BuscarUsuarioPorId(avaliacao.UsuarioId);
            var produto = await _produtoService.RetornarProdutoPorId(avaliacao.ProdutoId);
            if (usuario == null)
                throw new NotFoundException("Usuario não encontrado");
            if (produto == null)
                throw new NotFoundException("Produto não encontrado");

            var result = await _avaliacaoService.AdicionarAvaliacao(avaliacao);
            if (result != null)
                return Ok(result);

            return BadRequest();
        }

        [HttpPut("avaliacao/{idAvaliacao}")]
        public async Task<IActionResult> Put([FromRoute]int idAvaliacao, [FromBody] UpdateAvaliacaoInputModel avaliacao)
        {
            var result = await _avaliacaoService.EditarAvaliacao(idAvaliacao, avaliacao);

            if (result != null)
                return Ok(result);

            return BadRequest();
        }

        [HttpDelete("avaliacao/{idAvaliacao}")]
        public async Task<IActionResult> Delete([FromRoute] int idAvaliacao)
        {
            try
            {
                await _avaliacaoService.RemoverAvaliacao(idAvaliacao);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

    }
}
