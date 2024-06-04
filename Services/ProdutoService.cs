using API_Avaliacao_Produtos_Servicos.Enums;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using API_Avaliacao_Produtos_Servicos.Services.Interfaces;

namespace API_Avaliacao_Produtos_Servicos.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService (IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> AdicionarProduto(ProdutoInputModel produto)
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

        public async Task<Produto> AlterarProduto(int id, ProdutoInputModel produto)
        {
            Produto produtoEntity = new Produto
            {
                Id = id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                FornecedorID = produto.FornecedorId
            };
            return await _produtoRepository.AlterarProduto(id, produtoEntity);
        }

        public async Task<Produto> AlterarProduto(ProdutoInputModel produto)
        {
            if (produto.Id == null)
                return null;
            Produto produtoEntity = new Produto
            {
                Id = produto.Id.Value,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                FornecedorID = produto.FornecedorId
            };
            return await _produtoRepository.AlterarProduto(produtoEntity);
        }

        public async Task DeletarProduto(int id)
        {
            await _produtoRepository.DeleteById(id);
        }

        public async Task<IEnumerable<Produto>> GetAllProdutos()
        {
            return await _produtoRepository.FindAll();
        }

        public async Task<Produto> RetornarProdutoPorId(int id)
        {
            return await _produtoRepository.RetornarProdutoPorId(id);
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
