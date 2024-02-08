using API_Avaliacao_Produtos_Servicos.Data;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;

namespace API_Avaliacao_Produtos_Servicos.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void FindAll()
        {
            throw new NotImplementedException();
        }

        public void FindById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
