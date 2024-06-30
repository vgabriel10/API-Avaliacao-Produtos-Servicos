using API_Avaliacao_Produtos_Servicos.Data;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;

namespace API_Avaliacao_Produtos_Servicos.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Categoria> AdicionarUsuario(Categoria usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<Categoria> BuscarUsuarioPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task DeletarUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Categoria> EditarUsuario(int id, Categoria usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Categoria>> RetornarTodosUsuarios()
        {
            throw new NotImplementedException();
        }
    }
}
