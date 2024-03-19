using API_Avaliacao_Produtos_Servicos.Enums;

namespace API_Avaliacao_Produtos_Servicos.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public CategoriaEnum Categoria { get; set; }
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public List<AvaliacaoEnum> Avaliacoes { get; set; }
        public List<Comentario> Comentarios { get; set; }
        public decimal Preco { get; set; }
        public bool Deletado { get; set; } = false;
    }
}
