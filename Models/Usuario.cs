namespace API_Avaliacao_Produtos_Servicos.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Nacionalidade { get; set; }
        public string Cidade { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Deletado { get; set; } = false;

        public virtual List<Comentario> Comentarios { get; set; }
        public virtual List<Avaliacao> Avaliacoes { get; set; }
    }
}
