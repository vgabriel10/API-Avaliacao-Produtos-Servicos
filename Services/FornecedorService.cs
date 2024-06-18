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
        private readonly IUsuarioService _usuaarioService;
        private readonly IProdutoService _produtoService;

        public FornecedorService(IFornecedorRepository fornecedorRepository, IUsuarioService usuarioService, IProdutoService produtoService, IFornecedorMapper fornecedorMapper) 
        {
            _fornecedorRepository = fornecedorRepository;
            _usuaarioService = usuarioService;
            _produtoService = produtoService;
            _fornecedorMapper = fornecedorMapper;
        }

        public async Task<FornecedorViewModel> AdicionarFornecedor(CreateFornecedorInputModel fornecedorInputModel)
        {
            var fornecedor = _fornecedorMapper.ConverterParaEntidade(fornecedorInputModel);
        }

        public async Task<FornecedorViewModel> AlterarFornecedor(int id, UpdateFornecedorInputModel fornecedorViewModel)
        {
            var fornecedor = await _fornecedorRepository.RetornarFornecedorPorId(id);
            if (fornecedor == null)
                throw new NotFoundException("Fornecedor não encontrado");

            fornecedor.Nome = fornecedorViewModel.Nome;
            fornecedor.Cnpj = fornecedorViewModel.Cnpj;
            fornecedor.Cpf = fornecedorViewModel.Cpf;
            fornecedor.Nacionalidade = fornecedorViewModel.Nacionalidade;
            fornecedor.Cidade = fornecedorViewModel.Cidade;
            fornecedor.DataCadastro = DateTime.Now;
            fornecedor.Deletado = false;

            var result = await _fornecedorRepository.AlterarFornecedor(id, fornecedor);

            if (result == null)
                throw new BadRequestException("erro ao tentar realizar a alteração no fornecedor");

            return result;            
        }

        public async Task DeletarFornecedor(int id)
        {
            await _fornecedorRepository.DeletarFornecedor(id);
                
        }

        public async Task DeletarRegistroFornecedor(int id)
        {
            await _fornecedorRepository.DeletarRegistroFornecedor(id);
        }

        public Task<FornecedorViewModel> RetornarFornecedorPorId(int id)
        {
            return _fornecedorRepository.RetornarFornecedorPorId(id);
        }

        public async Task<IEnumerable<FornecedorViewModel>> RetornarTodosFornecedores()
        {
            return await _fornecedorRepository.RetornarTodosFornecedores();
        }
    }
}
