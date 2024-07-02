using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using API_Avaliacao_Produtos_Servicos.Services.Interfaces;

namespace API_Avaliacao_Produtos_Servicos.Services
{
    public class CategoriaService : ICategoriaService
    {
        
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(ICategoriaRepository categoriaRepository) 
        { 
            _categoriaRepository = categoriaRepository;
        }

        public Task<CategoriaViewModel> AdicionarCategoria(CreateCategoriaInputModel categoriaInputModel)
        {
            throw new NotImplementedException();
        }

        public Task DeletarCategoria(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoriaViewModel> EditarCategoria(int id, UpdateCategoriaInputModel categoriaInputModel)
        {
            throw new NotImplementedException();
        }

        public Task<CategoriaViewModel> RetornarCategoriaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoriaViewModel>> RetornarTodasCategorias()
        {
            throw new NotImplementedException();
        }
    }
}
