using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Services.Interfaces
{
    public interface IUsuarioService
    {
        public Task<IEnumerable<UsuarioViewModel>> RetornarTodosUsuarios();
        public Task<UsuarioViewModel> BuscarUsuarioPorId(int id);
        public Task<UsuarioViewModel> AdicionarUsuario(CreateUsuarioInputModel usuario);
        public Task<UsuarioViewModel> EditarUsuario(int id,UpdateUsuarioInputModel usuario);
        public Task DeletarUsuario(int id);
    }
}
