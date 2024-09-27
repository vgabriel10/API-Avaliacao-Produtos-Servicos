using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Services.Interfaces
{
    public interface IAutenticacaoService
    {
        Task<UsuarioLoginViewModel> CadastrarUsuario(CreateUsuarioLoginInputModel usuarioLogin);
        Task AdicionarRolePadrao(UsuarioLogin usuarioLogin);
        Task<bool> UsuarioTemCadastro(UsuarioLogin usuarioLogin);
        Task<IEnumerable<string>> RetornarRolesDoUsuario(int idUsuario);
        Task<UsuarioLogin> RetornarUsuarioLoginComRolesPorEmail(string email);
        Task<UsuarioLogin> RetornarUsuarioLoginComRolesPorLogin(UsuarioLoginInputModel usuarioLogin);
    }
}
