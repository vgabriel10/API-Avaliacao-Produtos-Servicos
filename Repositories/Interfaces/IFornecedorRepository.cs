using API_Avaliacao_Produtos_Servicos.Models;

namespace API_Avaliacao_Produtos_Servicos.Repositories.Interfaces
{
    public interface IFornecedorRepository
    {
        Task<IEnumerable<Fornecedor>> RetornarTodosFornecedores();
        Task<Fornecedor> RetornarFornecedorPorId(int id);
        Task<Fornecedor> AdicionarFornecedor(Fornecedor fornecedor);
    }
}
