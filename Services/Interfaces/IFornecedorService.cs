using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;


namespace API_Avaliacao_Produtos_Servicos.Services.Interfaces
{
    public interface IFornecedorService
    {
        Task<IEnumerable<FornecedorViewModel>> RetornarTodosFornecedores(int pular, int quantItens);
        Task<FornecedorViewModel> RetornarFornecedorPorId(int id);
        Task<FornecedorViewModel> AdicionarFornecedor(CreateFornecedorInputModel fornecedor);
        Task<FornecedorViewModel> AlterarFornecedor(int id, UpdateFornecedorInputModel fornecedorViewModel);
        Task DeletarFornecedor(int id);
        Task DeletarRegistroFornecedor(int id);
        Task<int> QuantidadeFornecedoresAtivos();
        Task<int> QuantidadePaginas(int totalRegistros, int itensPagina);

    }
}
