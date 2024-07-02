using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.Mappers.Interfaces;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Models.Mappers
{
    public class CategoriaMapper : ICategoriaMapper
    {
        public Categoria ConverterParaEntidade(CreateCategoriaInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public Categoria ConverterParaEntidade(UpdateCategoriaInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public CategoriaViewModel ConverterParaViewModel(Categoria entidade)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoriaViewModel> ConverterParaViewModel(IEnumerable<Categoria> entidades)
        {
            throw new NotImplementedException();
        }
    }
}
