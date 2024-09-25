using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.Mappers.Interfaces;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Models.Mappers
{
    public class UsuarioLoginMapper : IUsuarioLoginMapper
    {
        public UsuarioLogin ConverterParaEntidade(CreateUsuarioLoginInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public UsuarioLogin ConverterParaEntidade(UpdateUsuarioLoginInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public CategoriaViewModel ConverterParaViewModel(UsuarioLogin entidade)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsuarioLoginViewModel> ConverterParaViewModel(IEnumerable<UsuarioLogin> entidades)
        {
            throw new NotImplementedException();
        }
    }
}
