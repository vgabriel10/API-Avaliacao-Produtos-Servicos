using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.Mappers.Interfaces;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using API_Avaliacao_Produtos_Servicos.Services.Interfaces;

namespace API_Avaliacao_Produtos_Servicos.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly IAutenticacaoRepository _autenticacaoRepository;
        private readonly IUsuarioLoginMapper _usuarioLoginMapper;
        public AutenticacaoService(IAutenticacaoRepository autenticacaoRepository, IUsuarioLoginMapper usuarioLoginMapper) 
        {
            _autenticacaoRepository = autenticacaoRepository;
            _usuarioLoginMapper = usuarioLoginMapper;
        }

        public async Task<UsuarioLoginViewModel> CadastrarUsuario(CreateUsuarioLoginInputModel usuarioLoginInputModel)
        {
            var usuarioLogin = new UsuarioLogin
            {
                Email = usuarioLoginInputModel.Email,
                Senha = usuarioLoginInputModel.Senha
            };
            var result = await _autenticacaoRepository.CadastrarUsuario(usuarioLogin);
            var resultConvertido = _usuarioLoginMapper.ConverterParaViewModel(result);
            await AdicionarRolePadrao(result);
            return resultConvertido;
        }

        public async Task AdicionarRolePadrao(UsuarioLogin usuarioLogin)
        {
            await _autenticacaoRepository.AdicionarRolePadrao(usuarioLogin);
        }

        public Task<bool> UsuarioTemCadastro(UsuarioLogin usuarioLogin)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> RetornarRolesDoUsuario(int idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
