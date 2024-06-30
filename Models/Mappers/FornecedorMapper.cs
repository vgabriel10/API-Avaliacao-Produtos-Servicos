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

        public FornecedorViewModel ConverterParaViewModel(Fornecedor entidade)
        {
            return new FornecedorViewModel
            {
                Nome = entidade.Nome,
                Cidade = entidade.Cidade,
                Cnpj = entidade.Cnpj,
                Cpf = entidade.Cpf,
                DataCadastro = entidade.DataCadastro,
                Nacionalidade = entidade.Nacionalidade
            };
        }

        public IEnumerable<FornecedorViewModel> ConverterParaViewModel(IEnumerable<Fornecedor> entidades)
        {
            List<FornecedorViewModel> fornecedoresViewModel = new List<FornecedorViewModel>();

            foreach (var fornecedor in entidades)
            {
                fornecedoresViewModel.Add(ConverterParaViewModel(fornecedor));
            }

            return fornecedoresViewModel;
        }
    }
}
