namespace API_Avaliacao_Produtos_Servicos.Models.Response
{
    public class ErroResponse
    {
        public bool Successo { get; set; } = false;
        public int Status { get; set; } = 500;
        public string Mensagem { get; set; } = string.Empty;
        public List<string> Erros { get; set; } = new List<string>();
    }
}
