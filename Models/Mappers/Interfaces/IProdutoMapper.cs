using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Models.Mappers.Interfaces
{
    public interface IProdutoMapper
    {
        Usuario ConverterParaEntidade (CreateUsuarioInputModel inputModel);
        Usuario ConverterParaEntidade(UpdateUsuarioInputModel inputModel);
        UsuarioViewModel ConverterParaViewModel (Usuario entidade);
        IEnumerable<UsuarioViewModel> ConverterParaViewModel(IEnumerable<Usuario> entidades);

    }
}
