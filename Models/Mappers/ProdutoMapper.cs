using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.Mappers.Interfaces;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Models.Mappers
{
    public class ProdutoMapper : IProdutoMapper
    {
        public Produto ConverterParaEntidade(CreateProdutoInputModel inputModel)
        {
            return new Produto
            {
                Nome = inputModel.Nome,
                Descricao = inputModel.Descricao,
                Preco = inputModel.Preco,
                FornecedorID = inputModel.FornecedorId,
                CategoriaId = inputModel.CategoriaId
            };
        }

        public Produto ConverterParaEntidade(UpdateProdutoInputModel inputModel)
        {
            return new Produto
            {
                Nome = inputModel.Nome,
                Descricao = inputModel.Descricao,
                Preco = inputModel.Preco,
                FornecedorID = inputModel.FornecedorId,
                CategoriaId = inputModel.CategoriaId
            };
        }

        public ProdutoViewModel ConverterParaViewModel(Produto entidade)
        {
            return new ProdutoViewModel
            {
                Nome = entidade.Nome,
                Descricao = entidade.Descricao,
                Preco = entidade.Preco,
                Fornecedor = new FornecedorViewModel
                {
                    Nome = entidade.Fornecedor.Nome,
                    Cidade = entidade.Fornecedor.Cidade,    
                    Cnpj = entidade.Fornecedor.Cnpj,
                    Cpf = entidade.Fornecedor.Cpf,
                    DataCadastro = entidade.Fornecedor.DataCadastro,
                    Nacionalidade = entidade.Fornecedor.Nacionalidade
                },
                Categoria =  new CategoriaViewMod
            }
        }

        public IEnumerable<ProdutoViewModel> ConverterParaViewModel(IEnumerable<Produto> entidades)
        {
            throw new NotImplementedException();
        }
    }
}
