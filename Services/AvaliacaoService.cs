using API_Avaliacao_Produtos_Servicos.Exceptions;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.Mappers.Interfaces;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using API_Avaliacao_Produtos_Servicos.Services.Interfaces;

namespace API_Avaliacao_Produtos_Servicos.Services
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly IAvaliacaoMapper _avaliacaoMapper;
        private readonly IAvaliacaoRepository _avaliacaoRepository;

        public AvaliacaoService (IAvaliacaoRepository avaliacaoRepository,
            IAvaliacaoMapper avaliacaoMapper)
        {
            _avaliacaoMapper = avaliacaoMapper;
            _avaliacaoRepository = avaliacaoRepository;
        }

        public async Task<AvaliacaoViewModel> AdicionarAvaliacao(CreateAvaliacaoInputModel avaliacaoInputModel)
        {
            try
            {
                var avaliacao = _avaliacaoMapper.ConverterParaEntidade(avaliacaoInputModel);
                await _avaliacaoRepository.AdicionarAvaliacao(avaliacao);
                return _avaliacaoMapper.ConverterParaViewModel(avaliacao);
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }

        public async Task<AvaliacaoViewModel> EditarAvaliacao(int idAvaliacao, UpdateAvaliacaoInputModel avaliacaoInputModel)
        {
            try
            {
                var avaliacao = _avaliacaoMapper.ConverterParaEntidade(avaliacaoInputModel);

                var result = await _avaliacaoRepository.EditarAvaliacao(idAvaliacao, avaliacao);
                return _avaliacaoMapper.ConverterParaViewModel(result);
            }
            catch (NotFoundException ex)
            {
                throw new NotFoundException("Avaliação não encontrada");
            }    
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }

        public async Task RemoverAvaliacao(int idAvaliacao)
        {
            await _avaliacaoRepository.RemoverAvaliacao(idAvaliacao);
        }

        public Task<AvaliacaoViewModel> RetornaAvaliacaoPorId(int idAvaliacao)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AvaliacaoViewModel>> RetornaAvaliacoesDoProduto(int idProduto)
        {
            var avaliacoes = await _avaliacaoRepository.RetornaAvaliacoesDoProduto(idProduto);
            return _avaliacaoMapper.ConverterParaViewModel(avaliacoes);
        }

        public async Task<IEnumerable<AvaliacaoViewModel>> RetornaTodasAvaliacoes()
        {
            var avaliacoes = await _avaliacaoRepository.RetornaTodasAvaliacoes();
            return _avaliacaoMapper.ConverterParaViewModel(avaliacoes);
        }
    }
}
