﻿using API_Avaliacao_Produtos_Servicos.Data;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
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
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> FindById(int id)
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
            _context.Remove(produto);
            await _context.SaveChangesAsync();
        }
    }
}
