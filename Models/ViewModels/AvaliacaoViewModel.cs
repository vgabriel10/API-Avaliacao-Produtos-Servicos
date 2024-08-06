using API_Avaliacao_Produtos_Servicos.Enums;

namespace API_Avaliacao_Produtos_Servicos.Models.ViewModels
{
    public class AvaliacaoViewModel
    {
        public int Id { get; set; }
        public UsuarioViewModel Usuario { get; set; }
        public ProdutoViewModel Produto { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public AvaliacaoEnum Nota { get; set; }
    }
}
