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
        public IActionResult Get()
        {
            var todasAvaliacoes = _avaliacaoService.RetornaTodasAvaliacoes();
            if (todasAvaliacoes != null)
                return Ok(todasAvaliacoes);

            return BadRequest();
        }

        [HttpGet("avaliacao/{idProduto}")]
        public IActionResult Get(int idProduto)
        {
            var avaliacoesDoProduto = _avaliacaoService.RetornaAvaliacoesDoProduto(idProduto);
            if (avaliacoesDoProduto != null)
                return Ok(avaliacoesDoProduto);

            return NotFound();
        }

        [HttpPost("avaliacao")]
        public IActionResult Post(AvaliacaoInputModel avaliacao)
        {
            var result = _avaliacaoService.AdicionarAvaliacao(avaliacao);
            if (result != null)
                return Ok(result);

            return BadRequest();
        }

        [HttpPut("avaliacao/{idAvaliacao}")]
        public IActionResult Put([FromRoute]int idAvaliacao, [FromBody] AvaliacaoInputModel avaliacao)
        {
            //var result = _avaliacaoService.EditarAvaliacao()
            return BadRequest();
        }

        [HttpDelete("avaliacao/{idAvaliacao}")]
        public IActionResult Delete([FromRoute] int idAvaliacao)
        {
            //_avaliacaoService.RemoverAvaliacao(idAvaliacao)
            return BadRequest();
        }

    }
}
