namespace API_Avaliacao_Produtos_Servicos.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual IEnumerable<UsuarioRole> UsuarioRoles { get; set; }
    }

}
