using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;

namespace API_Avaliacao_Produtos_Servicos.Services.Interfaces
{
    public interface IAvaliacaoService
    {
        Task<IEnumerable<Avaliacao>> RetornaTodasAvaliacoes();
        Task<Avaliacao> RetornaAvaliacoesDoProduto(int idProduto);
        Task<Avaliacao> AdicionarAvaliacao(AvaliacaoInputModel avaliacao);
        Task<Avaliacao> EditarAvaliacao(AvaliacaoInputModel avalidacao);
        Task RemoverAvaliacao();
    }
}
