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
        private readonly IUsuarioService _usuarioService;
        private readonly IProdutoService _produtoService;

        public AvaliacaoService (IAvaliacaoRepository avaliacaoRepository,
            IAvaliacaoMapper avaliacaoMapper,
            IUsuarioService usuarioService,
            IProdutoService produtoService)
        {
            _avaliacaoMapper = avaliacaoMapper;
            _avaliacaoRepository = avaliacaoRepository;
            _usuarioService = usuarioService;
            _produtoService = produtoService;
        }

        public async Task<AvaliacaoViewModel> AdicionarAvaliacao(CreateAvaliacaoInputModel avaliacaoInputModel)
        {
            try
            {
                var avaliacao = _avaliacaoMapper.ConverterParaEntidade(avaliacaoInputModel);

                var usuario = await _usuarioService.BuscarUsuarioPorId(avaliacao.UsuarioId);
                var produto = await _produtoService.RetornarProdutoPorId(avaliacao.ProdutoId);

                if (usuario == null)
                    throw new NotFoundException("Usuario não encontrado");

                if (produto == null)
                    throw new NotFoundException("Produto não encontrado");

                avaliacao.Usuario = usuario;
                avaliacao.Produto = produto;

                await _avaliacaoRepository.AdicionarAvaliacao(avaliacao);

                return _avaliacaoMapper.ConverterParaViewModel(avaliacao);

            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }

        public async Task<AvaliacaoViewModel> EditarAvaliacao(int idAvaliacao, CreateAvaliacaoInputModel avaliacaoInputModel)
        {
            try
            {

                var avaliacao = _avaliacaoMapper.ConverterParaEntidade(avaliacaoInputModel);

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }            
        }

        public async Task RemoverAvaliacao()
        {
            throw new NotImplementedException();
        }

        public async Task<AvaliacaoViewModel> RetornaAvaliacoesDoProduto(int idProduto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AvaliacaoViewModel>> RetornaTodasAvaliacoes()
        {
            var avaliacoes = await _avaliacaoRepository.RetornaTodasAvaliacoes();
            return _avaliacaoMapper.ConverterParaViewModel(avaliacoes);
        }
    }
}
