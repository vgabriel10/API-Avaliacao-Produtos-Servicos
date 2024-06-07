using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Services.Interfaces;

namespace API_Avaliacao_Produtos_Servicos.Services
{
    public class AvaliacaoService : IAvaliacaoService
    {
        public Task<Avaliacao> AdicionarAvaliacao(AvaliacaoInputModel avaliacao)
        {
            throw new NotImplementedException();
        }

        public Task<Avaliacao> EditarAvaliacao(AvaliacaoInputModel avalidacao)
        {
            throw new NotImplementedException();
        }

        public Task RemoverAvaliacao()
        {
            throw new NotImplementedException();
        }

        public Task<Avaliacao> RetornaAvaliacoesDoProduto(int idProduto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Avaliacao>> RetornaTodasAvaliacoes()
        {
            throw new NotImplementedException();
        }
    }
}
