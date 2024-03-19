using API_Avaliacao_Produtos_Servicos.Enums;
using API_Avaliacao_Produtos_Servicos.Models;

namespace API_Avaliacao_Produtos_Servicos.Services.Interfaces
{
    public interface ProdutoService
    {
        List<Produto> RetornarProdutosMaisBaratos(CategoriaEnum categoria);

        List<Produto> RetornarProdutosMaisBemAvaliados();
    }
}
