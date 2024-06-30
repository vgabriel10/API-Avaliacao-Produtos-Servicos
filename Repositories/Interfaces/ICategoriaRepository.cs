using API_Avaliacao_Produtos_Servicos.Models;

namespace API_Avaliacao_Produtos_Servicos.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> RetornarTodosUsuarios();
        Task<Categoria> BuscarUsuarioPorId(int id);
        Task<Categoria> AdicionarUsuario(Categoria usuario);
        Task<Categoria> EditarUsuario(int id, Categoria usuario);
        Task DeletarUsuario(int id);
    }
}
