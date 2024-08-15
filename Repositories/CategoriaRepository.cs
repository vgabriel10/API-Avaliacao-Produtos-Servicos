using API_Avaliacao_Produtos_Servicos.Data;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Avaliacao_Produtos_Servicos.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Categoria> AdicionarCategoria(Categoria categoria)
        {
            try
            {
                await _context.AddAsync(categoria);
                await _context.SaveChangesAsync();
                return categoria;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public async Task DeletarCategoria(int id)
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);
            if (categoria != null)
            {
                //_context.Categorias.Remove(categoria);
                categoria.Deletado = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Categoria> EditarCategoria(int id, Categoria categoria)
        {
            var categoriaExistente = await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);
            if (categoriaExistente == null)
                return null;

            categoriaExistente.Nome = categoria.Nome;
            categoriaExistente.Deletado = false;

            await _context.SaveChangesAsync();
            return categoriaExistente;
        }

        public async Task<int> QuantidadeCategoriasAtivas()
        {
            return await _context.Categorias.CountAsync(x => !x.Deletado);
        }

        public async Task<int> QuantidadePaginas(int totalRegistros, int itensPagina)
        {
            int totalPaginas = (int)Math.Ceiling((double)totalRegistros / itensPagina);
            if (totalPaginas < 0)
                totalPaginas = 1;
            return await Task.FromResult(totalPaginas);
        }

        public async Task<Categoria> RetornarCategoriaPorId(int id)
        {
            return await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id && !x.Deletado);
        }

        public async Task<IEnumerable<Categoria>> RetornarTodasCategorias(int pular, int quantItens)
        {
            return await _context.Categorias
                .Where(x => !x.Deletado)
                .Skip(pular)
                .Take(quantItens)
                .ToListAsync();
        }
    }
}
