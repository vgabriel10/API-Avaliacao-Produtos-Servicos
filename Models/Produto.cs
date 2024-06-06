using API_Avaliacao_Produtos_Servicos.Enums;

namespace API_Avaliacao_Produtos_Servicos.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public CategoriaEnum Categoria { get; set; }
        public int FornecedorID { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        //public List<AvaliacaoEnum> Avaliacoes { get; set; }
        //public List<Comentario> ComentarioID { get; set; }
        //public virtual Comentario Comentario { get; set; }
        public decimal Preco { get; set; }
        public bool Deletado { get; set; } = false;
        public DateTime DataCadastro { get; set; }

        public virtual List<Comentario> Comentarios { get; set; }

        //public int Id { get; set; }
        //public string Nome { get; set; }
        //public string Descricao { get; set; }
        //public CategoriaEnum Categoria { get; set; }
        //public Fornecedor Fornecedor { get; set; }
        //public int FornecedorIDDD { get; set; }
        //public List<AvaliacaoEnum> Avaliacoes { get; set; }
        //public List<Comentario> Comentarios { get; set; }
        //public Comentario Comentario { get; set; }
        //public decimal Preco { get; set; }
        //public bool Deletado { get; set; } = false;
    }
}
