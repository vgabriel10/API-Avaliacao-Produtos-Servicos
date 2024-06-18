using API_Avaliacao_Produtos_Servicos.Data;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Avaliacao_Produtos_Servicos.Repositories
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly AppDbContext _context;

        public AvaliacaoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Avaliacao> AdicionarAvaliacao(Avaliacao avaliacao)
        {
            // Anexar as entidades existentes ao contexto para evitar a duplicidade
            _context.Entry(avaliacao.Usuario).State = EntityState.Unchanged;
            _context.Entry(avaliacao.Produto).State = EntityState.Unchanged;

            _context.Avaliacoes.Add(avaliacao);
            await _context.SaveChangesAsync();
            return avaliacao;
        }

        public async Task<Avaliacao> EditarAvaliacao(int idAvaliacao, Avaliacao avalidacao)
        {
            var avaliacao = await _context.Avaliacoes
                .Include(p => p.Produto)
                .Include(u => u.Usuario)
                .FirstOrDefaultAsync(x => x.Id == idAvaliacao);

            avaliacao.Titulo = avalidacao.Titulo;
            avaliacao.Descricao = avaliacao.Descricao;
            avaliacao.Nota = avaliacao.Nota;

            _context.Avaliacoes.Update(avaliacao);
            await _context.SaveChangesAsync();

            return avaliacao;
        }

        public async Task RemoverAvaliacao(int idAvaliacao)
        {
            var avaliacao = await _context.Avaliacoes.FirstOrDefaultAsync(x => x.Id == idAvaliacao);

            if (avaliacao != null)
            {
                _context.Remove(avaliacao);
                await _context.SaveChangesAsync();
            }            
        }

        public async Task<Avaliacao> RetornaAvaliacaoPorId(int idAvaliacao)
        {
            return await _context.Avaliacoes.FirstOrDefaultAsync(x => x.Id == idAvaliacao);
        }

        public async Task<IEnumerable<Avaliacao>> RetornaAvaliacoesDoProduto(int idProduto)
        {
            return await _context.Avaliacoes
                .Include(p => p.Produto)
                .Include(u => u.Usuario)
                .Where(x => x.ProdutoId == idProduto)
                .ToListAsync();
        }

        public async Task<IEnumerable<Avaliacao>> RetornaTodasAvaliacoes()
        {
            return await _context.Avaliacoes
                .Include(p => p.Produto)
                .Include(u => u.Usuario)
                .ToListAsync();
        }
    }
}
