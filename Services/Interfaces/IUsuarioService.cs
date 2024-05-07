using API_Avaliacao_Produtos_Servicos.Models;

namespace API_Avaliacao_Produtos_Servicos.Services.Interfaces
{
    public interface IUsuarioService
    {
        public Task<IEnumerable<Usuario>> RetornarTodosUsuarios();
        public Task<Usuario> BuscarUsuarioPorId(int id);
        public Task<Usuario> AdicionarUsuario(Usuario usuario);
        public Task<Usuario> EditarUsuario(Usuario usuario);
        public Task DeletarUsuario(int id);
    }
}
