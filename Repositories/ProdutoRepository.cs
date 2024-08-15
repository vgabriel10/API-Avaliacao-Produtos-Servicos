using API_Avaliacao_Produtos_Servicos.Data;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;
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

        public async Task<IEnumerable<Produto>> FindAll(int skip, int take)
        {
            try
            {
                var produtos = await _context.Produtos
                    .Include(x => x.Fornecedor)
                    .Include(x => x.Categoria)
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();
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
                .Include(x => x.Fornecedor)
                .Include(x => x.Categoria)
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
                
                var fornecedor = _context.Fornecedores.First(x => x.Id == produto.FornecedorId);
                var categoria = _context.Categorias.First(x => x.Id == produto.CategoriaId);
                produto.Fornecedor = fornecedor;
                produto.Categoria = categoria;

                await _context.Produtos.AddAsync(produto);
                await _context.SaveChangesAsync();
                return produto;
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        public async Task<Produto> AlterarProduto(int id, Produto produtoUpdate)
        {
            var fornecedor = _context.Fornecedores.First(x => x.Id == produtoUpdate.FornecedorId);
            var categoria = _context.Categorias.First(x => x.Id == produtoUpdate.CategoriaId);
            var produto = await _context.Produtos.FindAsync(id);

            produto.Fornecedor = fornecedor;
            produto.Categoria = categoria;
            produto.Nome = produtoUpdate.Nome;
            produto.Descricao = produtoUpdate.Descricao;
            produto.Preco = produtoUpdate.Preco;
            produto.FornecedorId = produtoUpdate.FornecedorId;  
            produto.CategoriaId = produto.CategoriaId;

            _context.Update(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> AlterarProduto(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<int> QuantidadeProdutosAtivos()
        {
            return await _context.Produtos.CountAsync(x => !x.Deletado);
        }

        public Task<int> QuantidadePaginas(int totalItens, int itensPagina)
        {
            int totalPaginas = (int)Math.Ceiling((double)totalItens / itensPagina);
            return Task.FromResult(totalPaginas);
        }
    }
}
