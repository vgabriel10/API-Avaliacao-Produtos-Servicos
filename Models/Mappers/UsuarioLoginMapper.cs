using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.Mappers.Interfaces;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Models.Mappers
{
    public class UsuarioLoginMapper : IUsuarioLoginMapper
    {
        public UsuarioLogin ConverterParaEntidade(CreateUsuarioLoginInputModel inputModel)
        {
            return new UsuarioLogin
            {
                Email = inputModel.Email,
                Senha = inputModel.Senha,
            };
        }

        public UsuarioLogin ConverterParaEntidade(UpdateUsuarioLoginInputModel inputModel)
        {
            return new UsuarioLogin
            {
                Email = inputModel.Email,
                Senha = inputModel.Senha,
            };
        }

        public UsuarioLoginViewModel ConverterParaViewModel(UsuarioLogin entidade)
        {
            return new UsuarioLoginViewModel
            {
                Email = entidade.Email,
                Senha = entidade.Senha,
            };
        }

        public IEnumerable<UsuarioLoginViewModel> ConverterParaViewModel(IEnumerable<UsuarioLogin> entidades)
        {
            List<UsuarioLoginViewModel> usuariosViewModels = new List<UsuarioLoginViewModel>();
            foreach (var usuario in entidades)
            {
                usuariosViewModels.Add(ConverterParaViewModel(usuario));
            }

            return usuariosViewModels;
        }
    }
}
