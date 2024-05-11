using API_Avaliacao_Produtos_Servicos.Enums;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using API_Avaliacao_Produtos_Servicos.Services.Interfaces;
using API_Avaliacao_Produtos_Servicos.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService (IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> AdicionarProduto(ProdutoViewModel produto)
        {
            Produto produtoConvertido = new Produto
            {
                Nome = produto.Nome,
                Preco = produto.Preco,
                Descricao = produto.Descricao,
                FornecedorID = produto.FornecedorId,
            };
            return await _produtoRepository.AdicionarProduto(produtoConvertido);
        }

        public Task<Produto> AlterarProduto(int id, ProdutoViewModel produto)
        {
            throw new NotImplementedException();
        }

        public async Task DeletarProduto(int id)
        {
            await _produtoRepository.DeleteById(id);
        }

        public async Task<IEnumerable<Produto>> GetAllProdutos()
        {
            return await _produtoRepository.FindAll();
        }

        public Task<Produto> RetornarProdutoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Produto> RetornarProdutosMaisBaratos(CategoriaEnum categoria)
        {
            throw new NotImplementedException();
        }

        public List<Produto> RetornarProdutosMaisBemAvaliados()
        {
            throw new NotImplementedException();
        }
    }
}
