using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using API_Avaliacao_Produtos_Servicos.Services.Interfaces;
using API_Avaliacao_Produtos_Servicos.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        public FornecedorService(IFornecedorRepository fornecedorRepository) 
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task<Fornecedor> AdicionarFornecedor(FornecedorViewModel fornecedor)
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
