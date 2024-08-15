using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using API_Avaliacao_Produtos_Servicos.Services.Interfaces;
using API_Avaliacao_Produtos_Servicos.Exceptions;
using Microsoft.EntityFrameworkCore;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.Mappers.Interfaces;

namespace API_Avaliacao_Produtos_Servicos.Services
{
    public class FornecedorService : IFornecedorService
    {
        IFornecedorMapper _fornecedorMapper;
        private readonly IFornecedorRepository _fornecedorRepository;


        public FornecedorService(IFornecedorRepository fornecedorRepository, IFornecedorMapper fornecedorMapper) 
        {
            _fornecedorRepository = fornecedorRepository;
            _fornecedorMapper = fornecedorMapper;
        }

        public async Task<FornecedorViewModel> AdicionarFornecedor(CreateFornecedorInputModel fornecedorInputModel)
        {
            var fornecedor = _fornecedorMapper.ConverterParaEntidade(fornecedorInputModel);
            await _fornecedorRepository.AdicionarFornecedor(fornecedor);
            return _fornecedorMapper.ConverterParaViewModel(fornecedor);
        }

        public async Task<FornecedorViewModel> AlterarFornecedor(int id, UpdateFornecedorInputModel fornecedorInputModel)
        {
            var existeFornecedor = await _fornecedorRepository.RetornarFornecedorPorId(id);
            if (existeFornecedor == null)
                throw new NotFoundException("Fornecedor não encontrado");

            var fornecedor = _fornecedorMapper.ConverterParaEntidade(fornecedorInputModel);
            await _fornecedorRepository.AlterarFornecedor(id, fornecedor);
            return _fornecedorMapper.ConverterParaViewModel(fornecedor);          
        }

        public async Task DeletarFornecedor(int id)
        {
            var fornecedor = await RetornarFornecedorPorId(id);
            if (fornecedor == null)
                throw new NotFoundException("Fornecedor não encontrado");
            await _fornecedorRepository.DeletarFornecedor(id);                
        }

        public async Task DeletarRegistroFornecedor(int id)
        {
            await _fornecedorRepository.DeletarRegistroFornecedor(id);
        }

        public async Task<FornecedorViewModel> RetornarFornecedorPorId(int id)
        {
            var fornecedor = await _fornecedorRepository.RetornarFornecedorPorId(id);
            if (fornecedor == null)
                throw new NotFoundException("fornecedor não encontrado");
            return _fornecedorMapper.ConverterParaViewModel(fornecedor);
        }

        public async Task<IEnumerable<FornecedorViewModel>> RetornarTodosFornecedores(int pular, int quantItens)
        {
            // Garantir que o número da página e o tamanho sejam válidos
            pular = pular < 1 ? 1 : pular;
            quantItens = quantItens < 1 ? 20 : quantItens;

            // Calcular quantos itens pular (skip)
            int skip = (pular - 1) * quantItens;
            var fornecedores = await _fornecedorRepository.RetornarTodosFornecedores(skip, quantItens);
            return _fornecedorMapper.ConverterParaViewModel(fornecedores);
        }

        public async Task<int> QuantidadeFornecedoresAtivos()
        {
            return await _fornecedorRepository.QuantidadeFornecedoresAtivos();
        }

        public async Task<int> QuantidadePaginas(int totalRegistros, int itensPagina)
        {
            return await _fornecedorRepository.QuantidadePaginas(totalRegistros, itensPagina);
        }
    }
}
