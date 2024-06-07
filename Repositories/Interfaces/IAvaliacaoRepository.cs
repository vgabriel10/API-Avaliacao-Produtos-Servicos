using API_Avaliacao_Produtos_Servicos.Models;

namespace API_Avaliacao_Produtos_Servicos.Repositories.Interfaces
{
    public interface IAvaliacaoRepository
    {
        Task<IEnumerable<Avaliacao>> RetornaTodasAvaliacoes();
        Task<Avaliacao> RetornaAvaliacoesDoProduto(int idProduto);
        Task<Avaliacao> AdicionarAvaliacao(Avaliacao avaliacao);
        Task<Avaliacao> EditarAvaliacao(Avaliacao avalidacao);
        Task RemoverAvaliacao();
    }
}
