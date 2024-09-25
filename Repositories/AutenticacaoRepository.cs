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
            _context.AddAsync(usuarioLogin);
            _context.SaveChangesAsync();
            return usuarioLogin;
        }
    }
}
