using API_Avaliacao_Produtos_Servicos.Enums;

namespace API_Avaliacao_Produtos_Servicos.Models.InputModels
{
    public class AvaliacaoInputModel
    {
        public int UsuarioId { get; set; }
        public int ProdutoId { get; set; }
        public int? ComentarioId { get; set; }
        public virtual ComentarioInputModel? Comentario { get; set; }
        public AvaliacaoEnum Nota { get; set; }
    }
}
