using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Services.Interfaces
{
    public interface IUsuarioService
    {
        public Task<IEnumerable<Usuario>> RetornarTodosUsuarios();
        public Task<Usuario> BuscarUsuarioPorId(int id);
        public Task<Usuario> AdicionarUsuario(CreateUsuarioInputModel usuario);
        public Task<Usuario> EditarUsuario(int id,UsuarioViewModel usuario);
        public Task DeletarUsuario(int id);
    }
}
