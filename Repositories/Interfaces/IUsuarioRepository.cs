using API_Avaliacao_Produtos_Servicos.Models;

namespace API_Avaliacao_Produtos_Servicos.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> RetornarTodosUsuarios(int numeroPagina = 1, int itensPagina = 20); 
        Task<Usuario> BuscarUsuarioPorId(int id);
        Task<int> QuantidadeUsuariosAtivos();
        Task<int> QuantidadePaginas(int totalRegistros, int itensPagina);
        Task<Usuario> AdicionarUsuario(Usuario usuario, int usuarioLoginId);
        Task<Usuario> EditarUsuario(int id, Usuario usuario);
        Task DeletarUsuario(int id);
    }
}
