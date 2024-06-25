using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Models.Mappers.Interfaces
{
    public interface IProdutoMapper
    {
        Produto ConverterParaEntidade (CreateProdutoInputModel inputModel);
        Produto ConverterParaEntidade(UpdateProdutoInputModel inputModel);
        ProdutoViewModel ConverterParaViewModel (Produto entidade);
        IEnumerable<ProdutoViewModel> ConverterParaViewModel(IEnumerable<Produto> entidades);

    }
}
