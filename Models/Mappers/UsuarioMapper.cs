using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.Mappers.Interfaces;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Models.Mappers
{
    public class UsuarioMapper : IUsuarioMapper
    {
        public Usuario ConverterParaEntidade(CreateUsuarioInputModel inputModel)
        {
            return new Usuario
            {
                Nome = inputModel.Nome,
                Cpf = inputModel.Cpf,
                Cidade = inputModel.Cidade,
                Nacionalidade = inputModel.Nacionalidade,
                DataNascimento = inputModel.DataNascimento
            };
        }

        public Usuario ConverterParaEntidade(UpdateUsuarioInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public UsuarioViewModel ConverterParaViewModel(Usuario entidade)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsuarioViewModel> ConverterParaViewModel(IEnumerable<Usuario> entidades)
        {
            throw new NotImplementedException();
        }
    }
}
