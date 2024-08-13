using API_Avaliacao_Produtos_Servicos.Enums;
using API_Avaliacao_Produtos_Servicos.Exceptions;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.Mappers.Interfaces;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;
using API_Avaliacao_Produtos_Servicos.Repositories;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using API_Avaliacao_Produtos_Servicos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_Avaliacao_Produtos_Servicos.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoMapper _produtoMapper;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService (IProdutoRepository produtoRepository, IProdutoMapper produtoMapper)
        {
            _produtoRepository = produtoRepository;
            _produtoMapper = produtoMapper;
        }

        public async Task<ProdutoViewModel> AdicionarProduto(CreateProdutoInputModel produtoInputModel)
        {
            var produto = _produtoMapper.ConverterParaEntidade(produtoInputModel);
            produto = await _produtoRepository.AdicionarProduto(produto);
            return _produtoMapper.ConverterParaViewModel(produto);
           
        }

        public async Task<ProdutoViewModel> AlterarProduto(int id, UpdateProdutoInputModel produtoInputModel)
        {
            var produtoEntity = _produtoMapper.ConverterParaEntidade(produtoInputModel);
            var produto = await _produtoRepository.AlterarProduto(id, produtoEntity);
            return _produtoMapper.ConverterParaViewModel(produto);
        }

        public async Task DeletarProduto(int id)
        {
            await _produtoRepository.DeleteById(id);
        }

        public async Task<IEnumerable<ProdutoViewModel>> GetAllProdutos(int pagina, int itensPagina)
        {
            // Garantir que o número da página e o tamanho sejam válidos
            pagina = pagina < 1 ? 1 : pagina;
            itensPagina = itensPagina < 1 ? 10 : itensPagina;

            // Calcular quantos itens pular (skip)
            int skip = (pagina - 1) * itensPagina;

            var produtos = await _produtoRepository.FindAll(skip, itensPagina);
            return _produtoMapper.ConverterParaViewModel(produtos);
        }

        public async Task<int> QuantidadePaginas(int totalItens, int itensPagina)
        {
            return await _produtoRepository.QuantidadePaginas(totalItens, itensPagina);
        }

        public async Task<int> QuantidadeProdutosAtivos()
        {
            return await _produtoRepository.QuantidadeProdutosAtivos();
        }

        public async Task<ProdutoViewModel> RetornarProdutoPorId(int id)
        {
            var produto = await _produtoRepository.RetornarProdutoPorId(id);
            if (produto == null)
                throw new NotFoundException("Produto não encontrado");

            return _produtoMapper.ConverterParaViewModel(produto);
        }

        public List<ProdutoViewModel> RetornarProdutosMaisBaratos(CategoriaEnum categoria)
        {
            throw new NotImplementedException();
        }

        public List<ProdutoViewModel> RetornarProdutosMaisBemAvaliados()
        {
            throw new NotImplementedException();
        }
    }
}
