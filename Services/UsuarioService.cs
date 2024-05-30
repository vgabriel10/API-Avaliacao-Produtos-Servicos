using API_Avaliacao_Produtos_Servicos.Exceptions;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;
using API_Avaliacao_Produtos_Servicos.Repositories;
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

        public async Task<Usuario> AdicionarUsuario(UsuarioInputModel usuarioViewModel)
        {
            var usuario = new Usuario
            {
                Nome = usuarioViewModel.Nome,
                Cpf = usuarioViewModel.Cpf,
                Cidade = usuarioViewModel.Cidade,
                DataCadastro = DateTime.Now,
                DataNascimento = usuarioViewModel.DataNascimento,
                Deletado = false,
                Nacionalidade = usuarioViewModel.Nacionalidade
            };

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

        public async Task<Usuario> EditarUsuario(int id, UsuarioViewModel usuarioViewModel)
        {

            var usuario = await _usuarioRepository.BuscarUsuarioPorId(id);
            if (usuario == null)
                throw new NotFoundException("Fornecedor não encontrado");

            usuario.Nome = usuarioViewModel.Nome;
            usuario.DataNascimento = usuarioViewModel.DataNascimento;
            usuario.Cpf = usuarioViewModel.Cpf;
            usuario.Cidade = usuarioViewModel.Cidade;
            usuario.DataCadastro = DateTime.Now;
            usuario.Deletado = false;
            usuario.Nacionalidade = usuarioViewModel.Nacionalidade;


            var result = await _usuarioRepository.EditarUsuario(id, usuario);

            if (result == null)
                throw new BadRequestException("erro ao tentar realizar a alteração no usuario");

            return result;
        }

        public async Task<IEnumerable<Usuario>> RetornarTodosUsuarios()
        {
            return await _usuarioRepository.RetornarTodosUsuarios();
        }
    }
}
