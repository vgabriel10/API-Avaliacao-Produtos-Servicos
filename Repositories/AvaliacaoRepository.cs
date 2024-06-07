using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;

namespace API_Avaliacao_Produtos_Servicos.Repositories
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        public Task<Avaliacao> AdicionarAvaliacao(Avaliacao avaliacao)
        {
            throw new NotImplementedException();
        }

        public Task<Avaliacao> EditarAvaliacao(Avaliacao avalidacao)
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
