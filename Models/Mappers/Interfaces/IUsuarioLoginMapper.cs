using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Models.Mappers.Interfaces
{
    public interface IUsuarioLoginMapper
    {
        UsuarioLogin ConverterParaEntidade(UsuarioLoginInputModel inputModel);
        UsuarioLogin ConverterParaEntidade(CreateUsuarioLoginInputModel inputModel);
        UsuarioLogin ConverterParaEntidade(UpdateUsuarioLoginInputModel inputModel);
        UsuarioLoginViewModel ConverterParaViewModel(UsuarioLogin entidade);
        IEnumerable<UsuarioLoginViewModel> ConverterParaViewModel(IEnumerable<UsuarioLogin> entidades);
    }
}
