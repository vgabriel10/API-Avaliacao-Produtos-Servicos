using API_Avaliacao_Produtos_Servicos.Enums;
using API_Avaliacao_Produtos_Servicos.Models;

namespace API_Avaliacao_Produtos_Servicos.Models.ViewModels
{
    public class ProdutoViewModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public FornecedorViewModel Fornecedor { get; set; }
        public CategoriaViewModel Categoria { get; set; }
    }
}
