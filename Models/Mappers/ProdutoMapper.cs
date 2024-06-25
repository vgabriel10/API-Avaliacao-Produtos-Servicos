using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.Mappers.Interfaces;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Models.Mappers
{
    public class ProdutoMapper : IProdutoMapper
    {
        public Usuario ConverterParaEntidade(CreateUsuarioInputModel inputModel)
        {
            throw new NotImplementedException();
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
