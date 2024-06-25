using API_Avaliacao_Produtos_Servicos.Enums;

namespace API_Avaliacao_Produtos_Servicos.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public int FornecedorID { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public decimal Preco { get; set; }
        public bool Deletado { get; set; } = false;
        public DateTime DataCadastro { get; set; }
        public virtual List<Avaliacao> Avaliacoes { get; set; }
    }
}
