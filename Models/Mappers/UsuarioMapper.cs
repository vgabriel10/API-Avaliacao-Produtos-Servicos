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
            return new Usuario
            {
                Nome = inputModel.Nome,
                Cpf = inputModel.Cpf,
                Cidade = inputModel.Cidade,
                Nacionalidade = inputModel.Nacionalidade,
                DataNascimento = inputModel.DataNascimento
            };
        }

        public UsuarioViewModel ConverterParaViewModel(Usuario entidade)
        {
            return new UsuarioViewModel
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                Cpf = entidade.Cpf,
                Cidade = entidade.Cidade,
                Nacionalidade = entidade.Nacionalidade,
                DataNascimento = entidade.DataNascimento
            };
        }

        public IEnumerable<UsuarioViewModel> ConverterParaViewModel(IEnumerable<Usuario> entidades)
        {
            List<UsuarioViewModel> usuariosViewModels = new List<UsuarioViewModel>();
            foreach (var usuario in entidades)
            {
                usuariosViewModels.Add(ConverterParaViewModel(usuario));
            }

            return usuariosViewModels;
        }
    }
}
