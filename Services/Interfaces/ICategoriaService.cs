using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Services.Interfaces
{
    public interface ICategoriaService
    {
        public Task<IEnumerable<CategoriaViewModel>> RetornarTodasCategorias();
        public Task<CategoriaViewModel> RetornarCategoriaPorId(int id);
        public Task<CategoriaViewModel> AdicionarCategoria(CreateCategoriaInputModel categoriaInputModel);
        public Task<CategoriaViewModel> EditarCategoria(int id, UpdateCategoriaInputModel categoriaInputModel);
        public Task DeletarCategoria(int id);
    }
}
