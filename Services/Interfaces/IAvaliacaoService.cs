using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Services.Interfaces
{
    public interface IAvaliacaoService
    {
        Task<IEnumerable<AvaliacaoViewModel>> RetornaTodasAvaliacoes();
        Task<AvaliacaoViewModel> RetornaAvaliacoesDoProduto(int idProduto);
        Task<AvaliacaoViewModel> AdicionarAvaliacao(AvaliacaoInputModel avaliacao);
        Task<AvaliacaoViewModel> EditarAvaliacao(AvaliacaoInputModel avalidacao);
        Task RemoverAvaliacao();
    }
}
