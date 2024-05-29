using API_Avaliacao_Produtos_Servicos.Data;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;
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

        public async Task<Fornecedor> AlterarFornecedor(int id, Fornecedor fornecedor)
        {

             _context.Fornecedores.Update(fornecedor);
            await _context.SaveChangesAsync();
            return fornecedor;
        }

        public async Task DeletarFornecedor(int id)
        {
            var fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(x => x.Id == id);
            if (fornecedor != null)
            {
                fornecedor.Deletado = true;
                _context.Update(fornecedor);
            }
            
            await _context.SaveChangesAsync();
        }

        public async Task DeletarRegistroFornecedor(int id)
        {
            var fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(fornecedor);
            await _context.SaveChangesAsync();
        }

        public async Task<Fornecedor> RetornarFornecedorPorId(int id)
        {
            return await _context.Fornecedores.FirstOrDefaultAsync(x => x.Id == id && x.Deletado == false);
        }

        public async Task<IEnumerable<Fornecedor>> RetornarTodosFornecedores()
        {
            return await _context.Fornecedores.Where(x => x.Deletado == false).ToListAsync();
        }
    }
}
