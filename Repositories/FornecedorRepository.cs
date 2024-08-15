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
            var fornecedorExistente = await _context.Fornecedores.FirstOrDefaultAsync(x => x.Id == id);
            if (fornecedorExistente == null)
                return null;

            fornecedorExistente.Nome = fornecedor.Nome;
            fornecedorExistente.Cnpj = fornecedor.Cnpj;
            fornecedorExistente.Cpf = fornecedor.Cpf;
            fornecedorExistente.Nacionalidade = fornecedor.Nacionalidade;
            fornecedorExistente.Cidade = fornecedor.Cidade;

            _context.Fornecedores.Update(fornecedorExistente);
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

        public async Task<int> QuantidadeFornecedoresAtivos()
        {
            return await _context.Fornecedores.CountAsync(x => !x.Deletado);
        }

        public async Task<int> QuantidadePaginas(int totalRegistros, int itensPagina)
        {
            int totalPaginas = (int)Math.Ceiling((double)totalRegistros / itensPagina);
            if (totalPaginas < 0)
                totalPaginas = 1;
            return await Task.FromResult(totalPaginas);
        }

        public async Task<Fornecedor> RetornarFornecedorPorId(int id)
        {
            return await _context.Fornecedores.FirstOrDefaultAsync(x => x.Id == id && x.Deletado == false);
        }

        public async Task<IEnumerable<Fornecedor>> RetornarTodosFornecedores(int pular, int quantItens)
        {
            return await _context.Fornecedores.Where(x => x.Deletado == false)
                .Skip(pular)
                .Take(quantItens)
                .ToListAsync();
        }
    }
}
