﻿using API_Avaliacao_Produtos_Servicos.Services.Interfaces;
using API_Avaliacao_Produtos_Servicos.ViewModels;
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
        public async Task<IActionResult> Get()
        {
            var fornecedores = await _fornecedorService.RetornarTodosFornecedores();

            if(fornecedores != null ) 
                return Ok(fornecedores);
            return BadRequest();
        }

        [HttpGet("fornecedor/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var result = await _fornecedorService.RetornarFornecedorPorId(id);
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        [HttpPost("fornecedor")]
        public async Task<IActionResult> Post(FornecedorViewModel fornecedor)
        {
            var result = await _fornecedorService.AdicionarFornecedor(fornecedor);

            if(result != null )
                return Ok(result);

            return BadRequest();
        }

    }
}
