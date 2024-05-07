using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using API_Avaliacao_Produtos_Servicos.Services.Interfaces;

namespace API_Avaliacao_Produtos_Servicos.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository) 
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> AdicionarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public async Task ApagarUsuario()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Usuario>> BuscarUsuarioPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> EditarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Usuario>> RetornarTodosUsuarios()
        {
            return await _usuarioRepository.RetornarTodosUsuarios();
        }
    }
}
