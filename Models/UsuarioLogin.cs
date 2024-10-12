namespace API_Avaliacao_Produtos_Servicos.Models
{
    public class UsuarioLogin
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public virtual IEnumerable<UsuarioRole> UsuarioRoles { get; set; }
    }
}
