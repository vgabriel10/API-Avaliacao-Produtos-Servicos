using API_Avaliacao_Produtos_Servicos.Models;

namespace API_Avaliacao_Produtos_Servicos.Repositories.Interfaces
{
    public interface IFornecedorRepository
    {
        Task<IEnumerable<Fornecedor>> BuscarTodosFornecedores();
        Task<Fornecedor> BuscarFornecedorPorId(int id);
        Task<Fornecedor> AdicionarFornecedor(Fornecedor fornecedor);
    }
}
