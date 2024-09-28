namespace API_Avaliacao_Produtos_Servicos.Models
{
    public class UsuarioRole
    {
        public int UsuarioId { get; set; }
        public UsuarioLogin Usuario { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

    }

}
