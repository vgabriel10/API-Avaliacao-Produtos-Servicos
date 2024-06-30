using API_Avaliacao_Produtos_Servicos.Exceptions;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.Mappers.Interfaces;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;
using API_Avaliacao_Produtos_Servicos.Repositories;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using API_Avaliacao_Produtos_Servicos.Services.Interfaces;

namespace API_Avaliacao_Produtos_Servicos.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioMapper _usuarioMapper;

        public UsuarioService(
            IUsuarioRepository usuarioRepository,IUsuarioMapper usuarioMapper) 
        {
            _usuarioRepository = usuarioRepository;
            _usuarioMapper = usuarioMapper;
        }

        public async Task<UsuarioViewModel> AdicionarUsuario(CreateUsuarioInputModel usuarioInputModel)
        {
            var usuario = _usuarioMapper.ConverterParaEntidade(usuarioInputModel);
            usuario.DataCadastro = DateTime.Now;

            var result = await _usuarioRepository.AdicionarUsuario(usuario);
            if (result == null)
                throw new BadRequestException("Erro ao adicionar novo usuário");
            return _usuarioMapper.ConverterParaViewModel(result);
        }

        public async Task DeletarUsuario(int id)
        {
            await _usuarioRepository.DeletarUsuario(id);
        }

        public async Task<UsuarioViewModel> BuscarUsuarioPorId(int id)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioPorId(id);
            return _usuarioMapper.ConverterParaViewModel(usuario);
        }

        public async Task<UsuarioViewModel> EditarUsuario(int id, UpdateUsuarioInputModel usuarioInputModel)
        {

            var existeUsuario = await _usuarioRepository.BuscarUsuarioPorId(id);
            if (existeUsuario == null)
                throw new NotFoundException("Fornecedor não encontrado");

            var usuario = _usuarioMapper.ConverterParaEntidade(usuarioInputModel);

            var result = await _usuarioRepository.EditarUsuario(id, usuario);

            if (result == null)
                throw new BadRequestException("erro ao tentar realizar a alteração no usuario");

            return _usuarioMapper.ConverterParaViewModel(result);
        }

        public async Task<IEnumerable<UsuarioViewModel>> RetornarTodosUsuarios()
        {
            var usuarios = await _usuarioRepository.RetornarTodosUsuarios();
            return _usuarioMapper.ConverterParaViewModel(usuarios);
        }
    }
}
