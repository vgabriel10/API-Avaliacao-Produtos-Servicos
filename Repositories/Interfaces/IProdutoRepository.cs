using API_Avaliacao_Produtos_Servicos.Data;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API_Avaliacao_Produtos_Servicos.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        public Task<IEnumerable<Produto>> FindAll(int skip, int take);
        public Task<Produto> RetornarProdutoPorId(int id);
        public Task<Produto> AlterarProduto(int id, Produto produto);
        public Task<Produto> AlterarProduto(Produto produto);
        public Task DeleteById(int id);
        public Task<Produto> AdicionarProduto(Produto produto);
        Task<int> QuantidadeProdutosAtivos();
        Task<int> QuantidadePaginas(int totalItens, int itensPagina);
    }
}
