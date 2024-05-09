﻿using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Services.Interfaces
{
    public interface IFornecedorService
    {
        Task<IEnumerable<Fornecedor>> RetornarTodosFornecedores();
        Task<Fornecedor> RetornarFornecedorPorId(int id);
        Task<Fornecedor> AdicionarFornecedor(FornecedorViewModel fornecedor);
        
    }
}
