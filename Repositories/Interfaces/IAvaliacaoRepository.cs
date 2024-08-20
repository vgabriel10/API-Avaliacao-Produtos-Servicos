using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Repositories.Interfaces
{
    public interface IAvaliacaoRepository
    {
        Task<IEnumerable<Avaliacao>> RetornaTodasAvaliacoes(int pular, int quantItens);
        Task<Avaliacao> RetornaAvaliacaoPorId(int idAvaliacao);
        Task<IEnumerable<Avaliacao>> RetornaAvaliacoesDoProduto(int idProduto, int pular, int quantItens);
        Task<Avaliacao> AdicionarAvaliacao(Avaliacao avaliacao);
        Task<Avaliacao> EditarAvaliacao(int idAvaliacao, Avaliacao avalidacao);
        Task RemoverAvaliacao(int idAvaliacao);
        Task<int> QuantidadeAvaliacoesAtivas();
        Task<int> QuantidadePaginas(int totalRegistros, int itensPagina);
        Task<int> QuantidadeAvaliacoesDoProduto(int idProduto);
    }
}
