using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using API_Avaliacao_Produtos_Servicos.Services.Interfaces;

namespace API_Avaliacao_Produtos_Servicos.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly IAutenticacaoRepository _autenticacaoRepository;
        public AutenticacaoService(IAutenticacaoRepository autenticacaoRepository) 
        {
            _autenticacaoRepository = autenticacaoRepository;
        }
        public async Task<UsuarioLoginViewModel> CadastrarUsuario(CreateUsuarioLoginInputModel usuarioLoginInputModel)
        {
            var usuarioLogin = new UsuarioLogin
            {
                Email = usuarioLoginInputModel.Email,
                Senha = usuarioLoginInputModel.Senha
            };
            var result = await _autenticacaoRepository.CadastrarUsuario(usuarioLogin);
            var resultConvertido = 
            return result;
        }
    }
}
