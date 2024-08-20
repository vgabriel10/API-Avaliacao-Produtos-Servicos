using API_Avaliacao_Produtos_Servicos.Models;

namespace API_Avaliacao_Produtos_Servicos.Repositories.Interfaces
{
    public interface IFornecedorRepository
    {
        Task<IEnumerable<Fornecedor>> RetornarTodosFornecedores(int pular, int quantItens);
        Task<Fornecedor> RetornarFornecedorPorId(int id);
        Task<Fornecedor> AdicionarFornecedor(Fornecedor fornecedor);
        Task<Fornecedor> AlterarFornecedor (int id, Fornecedor fornecedor);
        Task DeletarFornecedor(int id);
        Task DeletarRegistroFornecedor(int id);
        Task<int> QuantidadeFornecedoresAtivos();
        Task<int> QuantidadePaginas(int totalRegistros, int itensPagina);
    }
}
