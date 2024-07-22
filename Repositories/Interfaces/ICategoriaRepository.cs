using API_Avaliacao_Produtos_Servicos.Models;

namespace API_Avaliacao_Produtos_Servicos.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> RetornarTodasCategorias();
        Task<Categoria> RetornarCategoriaPorId(int id);
        Task<Categoria> AdicionarCategoria(Categoria categoria);
        Task<Categoria> EditarCategoria(int id, Categoria categoria);
        Task DeletarCategoria(int id);
    }
}
