namespace API_Avaliacao_Produtos_Servicos.Models.InputModels
{
    public class UpdateUsuarioInputModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Nacionalidade { get; set; }
        public string Cidade { get; set; }
    }
}
