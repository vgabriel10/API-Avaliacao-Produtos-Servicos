using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;


namespace API_Avaliacao_Produtos_Servicos.Services.Interfaces
{
    public interface IFornecedorService
    {
        Task<IEnumerable<FornecedorViewModel>> RetornarTodosFornecedores();
        Task<FornecedorViewModel> RetornarFornecedorPorId(int id);
        Task<FornecedorViewModel> AdicionarFornecedor(CreateFornecedorInputModel fornecedor);
        Task<FornecedorViewModel> AlterarFornecedor(int id, UpdateFornecedorInputModel fornecedorViewModel);
        Task DeletarFornecedor(int id);
        Task DeletarRegistroFornecedor(int id);

    }
}
