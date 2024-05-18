using API_Avaliacao_Produtos_Servicos.Enums;
using API_Avaliacao_Produtos_Servicos.Models;

namespace API_Avaliacao_Produtos_Servicos.ViewModels
{
    public class ProdutoViewModel
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        //public CategoriaEnum Categoria { get; set; }
        //public int FornecedorID { get; set; }
        public decimal Preco { get; set; }
        public int FornecedorId { get; set; }
    }
}
