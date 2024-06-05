using API_Avaliacao_Produtos_Servicos.Enums;

namespace API_Avaliacao_Produtos_Servicos.Models.ViewModels
{
    public class FornecedorViewModel
    {
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
        public string Nacionalidade { get; set; }
        public string Cidade { get; set; }
    }
}
