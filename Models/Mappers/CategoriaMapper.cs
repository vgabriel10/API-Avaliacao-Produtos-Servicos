using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.Mappers.Interfaces;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Models.Mappers
{
    public class CategoriaMapper : ICategoriaMapper
    {
        public Categoria ConverterParaEntidade(CreateCategoriaInputModel inputModel)
        {
            return new Categoria
            {
                Nome = inputModel.Nome,
            };
        }

        public Categoria ConverterParaEntidade(UpdateCategoriaInputModel inputModel)
        {
            return new Categoria
            {
                Nome = inputModel.Nome,
            };
        }

        public CategoriaViewModel ConverterParaViewModel(Categoria entidade)
        {
            return new CategoriaViewModel
            {
                Id = entidade.Id,
                Nome = entidade.Nome,                
            };
        }

        public IEnumerable<CategoriaViewModel> ConverterParaViewModel(IEnumerable<Categoria> entidades)
        {
            List<CategoriaViewModel> categoriaViewModels = new List<CategoriaViewModel>();
            foreach (var categoria in entidades)
            {
                categoriaViewModels.Add(ConverterParaViewModel(categoria));
            }

            return categoriaViewModels;
        }
    }
}
