using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Models.Mappers.Interfaces
{
    public interface ICategoriaMapper
    {
        Categoria ConverterParaEntidade(CreateCategoriaInputModel inputModel);
        Categoria ConverterParaEntidade(UpdateCategoriaInputModel inputModel);
        CategoriaViewModel ConverterParaViewModel(Categoria entidade);
        IEnumerable<CategoriaViewModel> ConverterParaViewModel(IEnumerable<Categoria> entidades);
    }
}
