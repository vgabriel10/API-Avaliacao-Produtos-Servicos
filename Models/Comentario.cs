namespace API_Avaliacao_Produtos_Servicos.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public int AvaliacaoId { get; set; }
        public virtual Avaliacao Avaliacao { get; set; }
    }
}
