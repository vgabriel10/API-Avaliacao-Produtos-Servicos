﻿using API_Avaliacao_Produtos_Servicos.Enums;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoViewModel>> GetAllProdutos();
        List<ProdutoViewModel> RetornarProdutosMaisBaratos(CategoriaEnum categoria);

        List<ProdutoViewModel> RetornarProdutosMaisBemAvaliados();
        Task<ProdutoViewModel> AdicionarProduto (CreateProdutoInputModel produto);

        Task<ProdutoViewModel> RetornarProdutoPorId(int id);
        Task<ProdutoViewModel> AlterarProduto(int id, UpdateProdutoInputModel produto);
        Task<ProdutoViewModel> AlterarProduto(UpdateProdutoInputModel produto);
        Task DeletarProduto(int id);

    }
}
