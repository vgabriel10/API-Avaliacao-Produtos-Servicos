using API_Avaliacao_Produtos_Servicos.Models;

namespace API_Avaliacao_Produtos_Servicos.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> RetornarTodosUsuarios(); 
        Task<Usuario> BuscarUsuarioPorId(int id);
        Task<Usuario> AdicionarUsuario(Usuario usuario);
        Task<Usuario> EditarUsuario(int id, Usuario usuario);
        Task DeletarUsuario(int id);
    }
}
