namespace API_Avaliacao_Produtos_Servicos.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdProduto { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
    }
}
