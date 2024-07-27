using API_Avaliacao_Produtos_Servicos.Enums;
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
            Produto produtoConvertido = new Produto
            {
                Nome = produtoInputModel.Nome,
                Preco = produtoInputModel.Preco,
                Descricao = produtoInputModel.Descricao,
                FornecedorId = produtoInputModel.FornecedorId,
                CategoriaId = produtoInputModel.CategoriaId,
            };

            var produto = _produtoMapper.ConverterParaEntidade(produtoInputModel);
            produto = await _produtoRepository.AdicionarProduto(produtoConvertido);
            return _produtoMapper.ConverterParaViewModel(produto);
           
        }

        public async Task<ProdutoViewModel> AlterarProduto(int id, UpdateProdutoInputModel produtoInputModel)
        {
            //Produto produtoEntity = new Produto
            //{
            //    Id = id,
            //    Nome = produtoInputModel.Nome,
            //    Descricao = produtoInputModel.Descricao,
            //    Preco = produtoInputModel.Preco,
            //    FornecedorId = produtoInputModel.FornecedorId,
            //    CategoriaId = produtoInputModel.CategoriaId
            //};

            var produtoEntity = _produtoMapper.ConverterParaEntidade(produtoInputModel);

            var produto = await _produtoRepository.AlterarProduto(id, produtoEntity);

            return _produtoMapper.ConverterParaViewModel(produto);
        }

        public async Task DeletarProduto(int id)
        {
            await _produtoRepository.DeleteById(id);
        }

        public async Task<IEnumerable<ProdutoViewModel>> GetAllProdutos()
        {
            var produtos = await _produtoRepository.FindAll();
            return _produtoMapper.ConverterParaViewModel(produtos);
        }

        public async Task<ProdutoViewModel> RetornarProdutoPorId(int id)
        {
            var produto = await _produtoRepository.RetornarProdutoPorId(id);
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
