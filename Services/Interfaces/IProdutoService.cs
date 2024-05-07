using API_Avaliacao_Produtos_Servicos.Enums;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetAllProdutos();
        List<Produto> RetornarProdutosMaisBaratos(CategoriaEnum categoria);

        List<Produto> RetornarProdutosMaisBemAvaliados();
        Task<Produto> AdicionarProduto (ProdutoViewModel produto);

        Task<Produto> RetornarProdutoPorId(int id);
        Task<Produto> AlterarProduto(int id, ProdutoViewModel produto);
        Task DeletarProduto(int id);

    }
}
