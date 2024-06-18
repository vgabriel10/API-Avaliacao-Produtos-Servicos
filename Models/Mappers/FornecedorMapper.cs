using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.Mappers.Interfaces;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Models.Mappers
{
    public class FornecedorMapper : IFornecedorMapper
    {
        public Fornecedor ConverterParaEntidade(CreateFornecedorInputModel inputModel)
        {
            return new Fornecedor
            {
                Nome = inputModel.Nome,
                Cidade = inputModel.Cidade,
                Cnpj = inputModel.Cnpj,
                Cpf = inputModel.Cpf,
                DataCadastro = DateTime.Now,
                Deletado = false,
                Nacionalidade = inputModel.Nacionalidade
            };
        }

        public Fornecedor ConverterParaEntidade(UpdateFornecedorInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public FornecedorViewModel ConverterParaViewModel(Fornecedor entidade)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FornecedorViewModel> ConverterParaViewModel(IEnumerable<Fornecedor> entidades)
        {
            throw new NotImplementedException();
        }
    }
}
