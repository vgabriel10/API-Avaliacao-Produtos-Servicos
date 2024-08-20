namespace API_Avaliacao_Produtos_Servicos.Models.InputModels
{
    public class PaginacaoInputModel
    {
        public int PageNumber { get; set; } = 1; // Padrão para a primeira página
        public int PageSize { get; set; } = 10;  // Padrão para 10 itens por página
    }
}
