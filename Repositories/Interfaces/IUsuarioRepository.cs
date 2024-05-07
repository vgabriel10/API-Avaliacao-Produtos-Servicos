using API_Avaliacao_Produtos_Servicos.Models;

namespace API_Avaliacao_Produtos_Servicos.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> BuscarTodosUsuarios(); 
        Task<Usuario> BuscarUsuarioPorId(int id);
        Task<Usuario> AdicionarUsuario(Usuario usuario);
        Task DeletarUsuario(int id);
    }
}
