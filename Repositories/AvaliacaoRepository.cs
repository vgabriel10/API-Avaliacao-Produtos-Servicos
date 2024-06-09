using API_Avaliacao_Produtos_Servicos.Data;
using API_Avaliacao_Produtos_Servicos.Models;
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
            _context.Avaliacoes.Add(avaliacao);
            await _context.SaveChangesAsync();
            return avaliacao;
        }

        public async Task<Avaliacao> EditarAvaliacao(Avaliacao avalidacao)
        {
            throw new NotImplementedException();
        }

        public async Task RemoverAvaliacao()
        {
            throw new NotImplementedException();
        }

        public async Task<Avaliacao> RetornaAvaliacoesDoProduto(int idProduto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Avaliacao>> RetornaTodasAvaliacoes()
        {
            return await _context.Avaliacoes.ToListAsync();
        }
    }
}
