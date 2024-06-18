using API_Avaliacao_Produtos_Servicos.Enums;

namespace API_Avaliacao_Produtos_Servicos.Models.InputModels
{
    public class UpdateAvaliacaoInputModel
    {
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public AvaliacaoEnum Nota { get; set; }
    }
}
