using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Models.Mappers.Interfaces
{
    public interface IFornecedorMapper
    {
        Fornecedor ConverterParaEntidade (CreateFornecedorInputModel inputModel);
        Fornecedor ConverterParaEntidade(UpdateFornecedorInputModel inputModel);
        FornecedorViewModel ConverterParaViewModel (Fornecedor entidade);
        IEnumerable<FornecedorViewModel> ConverterParaViewModel(IEnumerable<Fornecedor> entidades);

    }
}
