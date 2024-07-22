namespace API_Avaliacao_Produtos_Servicos.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Deletado { get; set; } = false;
    }
}
