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
            return await _usuarioRepository.AdicionarUsuario(usuario);
        }

        public async Task DeletarUsuario(int id)
        {
            await _usuarioRepository.DeletarUsuario(id);
        }

        public async Task<Usuario> BuscarUsuarioPorId(int id)
        {
            return await _usuarioRepository.BuscarUsuarioPorId(id);
        }

        public async Task<Usuario> EditarUsuario(Usuario usuario)
        {
            return await _usuarioRepository.EditarUsuario(usuario);
        }

        public async Task<IEnumerable<Usuario>> RetornarTodosUsuarios()
        {
            return await _usuarioRepository.RetornarTodosUsuarios();
        }
    }
}
