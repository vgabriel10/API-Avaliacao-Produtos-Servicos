using API_Avaliacao_Produtos_Servicos.Data;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using API_Avaliacao_Produtos_Servicos.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace API_Avaliacao_Produtos_Servicos.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly AppDbContext _context;
        public FornecedorRepository(AppDbContext context) 
        {
            _context = context;
        }
        public async Task<Fornecedor> AdicionarFornecedor(Fornecedor fornecedor)
        {
            _context.Fornecedores.Add(fornecedor);
            await _context.SaveChangesAsync();
            return fornecedor;
        }

        public async Task<Fornecedor> RetornarFornecedorPorId(int id)
        {
            return await _context.Fornecedores.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Fornecedor>> RetornarTodosFornecedores()
        {
            return await _context.Fornecedores.ToListAsync();
        }
    }
}
