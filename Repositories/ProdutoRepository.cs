using API_Avaliacao_Produtos_Servicos.Data;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using API_Avaliacao_Produtos_Servicos.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace API_Avaliacao_Produtos_Servicos.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }       

        public async Task<IEnumerable<Produto>> FindAll()
        {
            try
            {
                var produtos = await _context.Produtos.ToListAsync();
                return produtos;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public async Task<Produto> RetornarProdutoPorId(int id)
        {
            return await _context.Produtos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Produto> Update()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteById(int id)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
            if (produto  != null)
                _context.Remove(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<Produto> AdicionarProduto(Produto produto)
        {
            try
            {
                _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();
                return produto;
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        public async Task<Produto> AlterarProduto(int id, Produto produto)
        {

            return null;
        }

        public async Task<Produto> AlterarProduto(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return produto;
        }
    }
}
