using API_Avaliacao_Produtos_Servicos.Data;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
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
        public AvaliacaoController(IAvaliacaoService avaliacaoService)
        {
            _avaliacaoService = avaliacaoService;
        }

        [HttpGet("avaliacao")]
        public async Task<IActionResult> Get()
        {
            var todasAvaliacoes = await _avaliacaoService.RetornaTodasAvaliacoes();
            if (todasAvaliacoes != null)
                return Ok(todasAvaliacoes);

            return BadRequest();
        }

        [HttpGet("avaliacao/{idProduto}")]
        public async Task<IActionResult> Get(int idProduto)
        {
            var avaliacoesDoProduto = await _avaliacaoService.RetornaAvaliacoesDoProduto(idProduto);
            if (avaliacoesDoProduto != null)
                return Ok(avaliacoesDoProduto);

            return NotFound();
        }

        [HttpPost("avaliacao")]
        public async Task<IActionResult> Post(CreateAvaliacaoInputModel avaliacao)
        {
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
