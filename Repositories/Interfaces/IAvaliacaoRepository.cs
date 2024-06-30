using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Repositories.Interfaces
{
    public interface IAvaliacaoRepository
    {
        Task<IEnumerable<Avaliacao>> RetornaTodasAvaliacoes();
        Task<Avaliacao> RetornaAvaliacaoPorId(int idAvaliacao);
        Task<IEnumerable<Avaliacao>> RetornaAvaliacoesDoProduto(int idProduto);
        Task<Avaliacao> AdicionarAvaliacao(Avaliacao avaliacao);
        Task<Avaliacao> EditarAvaliacao(int idAvaliacao, Avaliacao avalidacao);
        Task RemoverAvaliacao(int idAvaliacao);
    }
}
