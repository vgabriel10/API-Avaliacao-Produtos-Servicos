using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Services.Interfaces
{
    public interface IAvaliacaoService
    {
        Task<IEnumerable<AvaliacaoViewModel>> RetornaTodasAvaliacoes(int pular, int quantItens);
        Task<AvaliacaoViewModel> RetornaAvaliacaoPorId(int idAvaliacao);
        Task<IEnumerable<AvaliacaoViewModel>> RetornaAvaliacoesDoProduto(int idProduto, int pular, int quantItens);
        Task<AvaliacaoViewModel> AdicionarAvaliacao(CreateAvaliacaoInputModel avaliacao);
        Task<AvaliacaoViewModel> EditarAvaliacao(int idAvaliacao, UpdateAvaliacaoInputModel avalidacao);
        Task RemoverAvaliacao(int idAvaliacao);
        Task<int> QuantidadeAvaliacoesAtivas();
        Task<int> QuantidadePaginas(int totalRegistros, int itensPagina);
        Task<int> QuantidadeAvaliacoesDoProduto(int idProduto);
    }
}
