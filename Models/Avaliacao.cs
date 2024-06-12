using API_Avaliacao_Produtos_Servicos.Enums;

namespace API_Avaliacao_Produtos_Servicos.Models
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        //public int? ComentarioId { get; set; }
        //public virtual Comentario? Comentario { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public AvaliacaoEnum Nota { get; set; }
        public DateTime DataAvaliacao { get; set; }

    }
}
