using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.Mappers.Interfaces;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Models.Mappers
{
    public class AvaliacaoMapper : IAvaliacaoMapper
    {
        public Avaliacao ConverterParaEntidade(CreateAvaliacaoInputModel inputModel)
        {
            return new Avaliacao
            {
                Titulo = inputModel.Titulo,
                Descricao = inputModel.Descricao,
                Nota = inputModel.Nota,
                DataAvaliacao = DateTime.Now,
                ProdutoId = inputModel.ProdutoId,
                UsuarioId = inputModel.UsuarioId
            };
        }

        public IEnumerable<Avaliacao> ConverterParaEntidade(IEnumerable<CreateAvaliacaoInputModel> inputsModels)
        {
            List<Avaliacao> avaliacoes = new List<Avaliacao>();

            foreach (var avaliacao in inputsModels)
            {
                avaliacoes.Add(ConverterParaEntidade(avaliacao));
            }

            return avaliacoes;
        }

        public AvaliacaoViewModel ConverterParaViewModel(Avaliacao entidade)
        {
            return new AvaliacaoViewModel
            {
                Titulo = entidade.Titulo,
                Descricao = entidade.Descricao,
                Nota = entidade.Nota,
                Produto = new ProdutoViewModel
                {
                    Nome = entidade.Produto.Nome,
                    Descricao = entidade.Produto.Descricao,
                    FornecedorId = entidade.Produto.FornecedorID,
                    Preco = entidade.Produto.Preco
                },
                Usuario = new UsuarioViewModel
                {
                    Nome = entidade.Usuario.Nome,
                    Cpf = entidade.Usuario.Cpf,
                    Cidade = entidade.Usuario.Cidade,
                    Nacionalidade = entidade.Usuario.Nacionalidade,
                    DataNascimento = entidade.Usuario.DataNascimento
                }
            };
        }

        public IEnumerable<AvaliacaoViewModel> ConverterParaViewModel(IEnumerable<Avaliacao> entidades)
        {
            List<AvaliacaoViewModel> avaliacoesViewModel = new List<AvaliacaoViewModel>();

            foreach (var avaliacao in entidades)
            {
                avaliacoesViewModel.Add(ConverterParaViewModel(avaliacao));
            }

            return avaliacoesViewModel;
        }
    }
}
