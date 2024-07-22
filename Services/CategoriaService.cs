using API_Avaliacao_Produtos_Servicos.Exceptions;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.Mappers;
using API_Avaliacao_Produtos_Servicos.Models.Mappers.Interfaces;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;
using API_Avaliacao_Produtos_Servicos.Repositories;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using API_Avaliacao_Produtos_Servicos.Services.Interfaces;

namespace API_Avaliacao_Produtos_Servicos.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaMapper _categoriaMapper;
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(ICategoriaMapper categoriaMapper, ICategoriaRepository categoriaRepository) 
        { 
            _categoriaMapper = categoriaMapper;
            _categoriaRepository = categoriaRepository;
        }

        public async Task<CategoriaViewModel> AdicionarCategoria(CreateCategoriaInputModel categoriaInputModel)
        {
            var categoria = _categoriaMapper.ConverterParaEntidade(categoriaInputModel);

            var result = await _categoriaRepository.AdicionarCategoria(categoria);
            if (result == null)
                throw new BadRequestException("Erro ao adicionar nova categoria");
            return _categoriaMapper.ConverterParaViewModel(result);
        }

        public async Task DeletarCategoria(int id)
        {
            await _categoriaRepository.DeletarCategoria(id);
        }

        public async Task<CategoriaViewModel> EditarCategoria(int id, UpdateCategoriaInputModel categoriaInputModel)
        {
            var existeCategoria = _categoriaRepository.RetornarCategoriaPorId(id);
            if (existeCategoria == null)
            {
                throw new NotFoundException("Categoria não encontrada");
            }

            var categoria = _categoriaMapper.ConverterParaEntidade(categoriaInputModel);
            await _categoriaRepository.EditarCategoria(id, categoria);
            return _categoriaMapper.ConverterParaViewModel(categoria);

        }

        public async Task<CategoriaViewModel> RetornarCategoriaPorId(int id)
        {
            var categoria = await _categoriaRepository.RetornarCategoriaPorId(id);
            return _categoriaMapper.ConverterParaViewModel(categoria);
        }

        public async Task<IEnumerable<CategoriaViewModel>> RetornarTodasCategorias()
        {
            var categorias = await _categoriaRepository.RetornarTodasCategorias();
            return _categoriaMapper.ConverterParaViewModel(categorias);
        }
    }
}
