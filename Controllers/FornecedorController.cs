﻿using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.Response;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;
using API_Avaliacao_Produtos_Servicos.Services;
using API_Avaliacao_Produtos_Servicos.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Avaliacao_Produtos_Servicos.Controllers
{
    [ApiController]
    [Route(template: "api/v1")]
    public class FornecedorController : Controller
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpGet("fornecedor")]
        public async Task<IActionResult> Get([FromQuery] int pagina = 1, [FromQuery] int itensPagina = 20)
        {
            var fornecedores = await _fornecedorService.RetornarTodosFornecedores(pagina, itensPagina);

            if(fornecedores == null )
                return BadRequest();

            int totalItens = await _fornecedorService.QuantidadeFornecedoresAtivos();
            int totalPaginas = await _fornecedorService.QuantidadePaginas(totalItens, itensPagina);

            return Ok(new ApiResponse<FornecedorViewModel>
            {
                PaginaAtual = pagina,
                ItensPagina = fornecedores.Count(),
                TotalPaginas = totalPaginas,
                TotalItens = totalItens,
                Data = fornecedores,
                Success = true,
            });
        }

        [HttpGet("fornecedor/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var result = await _fornecedorService.RetornarFornecedorPorId(id);
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        [Authorize("Admin")]
        [HttpPost("fornecedor")]
        public async Task<IActionResult> Post(CreateFornecedorInputModel fornecedor)
        {
            var result = await _fornecedorService.AdicionarFornecedor(fornecedor);

            if(result != null )
                return Ok(result);

            return BadRequest();
        }

        [Authorize("Admin")]
        [HttpPut("fornecedor/{id}")]
        public async Task<IActionResult> Put([FromRoute] int id,
            [FromBody] UpdateFornecedorInputModel fornecedor)
        {
            var result = await _fornecedorService.AlterarFornecedor(id, fornecedor);
            if (result != null)
                return Ok(result);

            return BadRequest();
        }

        [Authorize("Admin")]
        [HttpDelete("fornecedor/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _fornecedorService.DeletarFornecedor(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
