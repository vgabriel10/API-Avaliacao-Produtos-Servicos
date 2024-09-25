using API_Avaliacao_Produtos_Servicos.Data;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;

namespace API_Avaliacao_Produtos_Servicos.Repositories
{
    public class AutenticacaoRepository : IAutenticacaoRepository
    {
        private readonly AppDbContext _context;
        public AutenticacaoRepository(AppDbContext context) 
        { 
            _context = context;
        }
        public async Task<UsuarioLogin> CadastrarUsuario(UsuarioLogin usuarioLogin)
        {
            await _context.AddAsync(usuarioLogin);
            await _context.SaveChangesAsync();
            return usuarioLogin;
        }

        public async Task AdicionarRolePadrao(UsuarioLogin usuarioLogin)
        {
            var usuarioRole = new UsuarioRole
            {
                RoleId = 2,
                UsuarioId = usuarioLogin.Id
            };

            await _context.UsuarioRoles.AddAsync(usuarioRole);
            await _context.SaveChangesAsync();
        }

        public Task<bool> UsuarioTemCadastro(UsuarioLogin usuarioLogin)
        {
            throw new NotImplementedException();
        }
    }
}
