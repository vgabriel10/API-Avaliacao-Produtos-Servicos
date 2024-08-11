using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Services.Interfaces
{
    public interface IUsuarioService
    {
        public Task<IEnumerable<UsuarioViewModel>> RetornarTodosUsuarios(int numeroPagina = 1, int itensPagina = 20);
        public Task<UsuarioViewModel> BuscarUsuarioPorId(int id);
        Task<int> QuantidadeUsuariosAtivos();
        Task<int> QuantidadePaginas(int totalRegistros,int itensPagina);
        public Task<UsuarioViewModel> AdicionarUsuario(CreateUsuarioInputModel usuario);
        public Task<UsuarioViewModel> EditarUsuario(int id,UpdateUsuarioInputModel usuario);
        public Task DeletarUsuario(int id);
    }
}
