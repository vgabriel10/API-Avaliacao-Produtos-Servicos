namespace API_Avaliacao_Produtos_Servicos.Models
{
    public class UsuarioLogin
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string[] Roles { get; set; }
    }
}
