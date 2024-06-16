using API_Avaliacao_Produtos_Servicos.Enums;

namespace API_Avaliacao_Produtos_Servicos.Models.InputModels
{
    public class CreateAvaliacaoInputModel
    {
        public int UsuarioId { get; set; }
        public int ProdutoId { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public AvaliacaoEnum Nota { get; set; }
    }
}
