using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using API_Avaliacao_Produtos_Servicos.Services.Interfaces;
using API_Avaliacao_Produtos_Servicos.Exceptions;
using Microsoft.EntityFrameworkCore;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        public FornecedorService(IFornecedorRepository fornecedorRepository) 
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task<Fornecedor> AdicionarFornecedor(FornecedorInputModel fornecedor)
        {
            if(fornecedor != null)
            {
                Fornecedor novoFornecedor = new Fornecedor()
                {
                    Nome = fornecedor.Nome,
                    Cidade = fornecedor.Cidade,
                    Cnpj = fornecedor.Cnpj,
                    Cpf = fornecedor.Cpf,
                    Pais = fornecedor.Pais,
                    DataCadastro = DateTime.Now,
                    Deletado = false
                };
                return await _fornecedorRepository.AdicionarFornecedor(novoFornecedor);
            }
            return null;
        }

        public async Task<Fornecedor> AlterarFornecedor(int id, FornecedorInputModel fornecedorViewModel)
        {
            var fornecedor = await _fornecedorRepository.RetornarFornecedorPorId(id);
            if (fornecedor == null)
                throw new NotFoundException("Fornecedor não encontrado");

            fornecedor.Nome = fornecedorViewModel.Nome;
            fornecedor.Cnpj = fornecedorViewModel.Cnpj;
            fornecedor.Cpf = fornecedorViewModel.Cpf;
            fornecedor.Pais = fornecedorViewModel.Pais;
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

        public Task<Fornecedor> RetornarFornecedorPorId(int id)
        {
            return _fornecedorRepository.RetornarFornecedorPorId(id);
        }

        public async Task<IEnumerable<Fornecedor>> RetornarTodosFornecedores()
        {
            return await _fornecedorRepository.RetornarTodosFornecedores();
        }
    }
}
