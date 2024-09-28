using API_Avaliacao_Produtos_Servicos.Data;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> UsuarioTemCadastro(UsuarioLogin usuarioLogin)
        {
            var usuario = await _context.UsuariosLogin.FirstOrDefaultAsync(x => x.Email == usuarioLogin.Email);
            if (usuario == null)
                return false;

            return true;
        }

        public Task<IEnumerable<string>> RetornarRolesDoUsuario(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public async Task<UsuarioLogin> RetornarUsuarioLoginComRolesPorEmail(string email)
        {
            return await _context.UsuariosLogin
                .Include(x => x.UsuarioRoles)
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<UsuarioLogin> RetornarUsuarioLoginComRolesPorLogin(UsuarioLogin usuarioLogin)
        {
            return await _context.UsuariosLogin
                .Include(x => x.UsuarioRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(x => x.Email == usuarioLogin.Email && x.Senha == usuarioLogin.Senha);
        }
    }
}
