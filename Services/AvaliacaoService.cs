using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using API_Avaliacao_Produtos_Servicos.Services.Interfaces;

namespace API_Avaliacao_Produtos_Servicos.Services
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;

        public AvaliacaoService (IAvaliacaoRepository avaliacaoRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
        }

        public async Task<Avaliacao> AdicionarAvaliacao(AvaliacaoInputModel avaliacaoInputModel)
        {
            var avaliacao = new Avaliacao
            {
                UsuarioId = avaliacaoInputModel.UsuarioId,
                ProdutoId = avaliacaoInputModel.ProdutoId,
                //ComentarioId = avaliacaoInputModel?.ComentarioId,
                Nota = avaliacaoInputModel.Nota,
                DataAvaliacao = DateTime.Now
            };

            return await _avaliacaoRepository.AdicionarAvaliacao(avaliacao);
        }

        public async Task<Avaliacao> EditarAvaliacao(AvaliacaoInputModel avaliacaoInputModel)
        {
            throw new NotImplementedException();
        }

        public async Task RemoverAvaliacao()
        {
            throw new NotImplementedException();
        }

        public async Task<Avaliacao> RetornaAvaliacoesDoProduto(int idProduto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Avaliacao>> RetornaTodasAvaliacoes()
        {
            return await _avaliacaoRepository.RetornaTodasAvaliacoes();
        }
    }
}
