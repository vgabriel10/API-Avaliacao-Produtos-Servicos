namespace API_Avaliacao_Produtos_Servicos.Models.Response
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        //public T Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string>? Erros { get; set; }

        public int PaginaAtual { get; set; }
        public int ItensPagina { get; set; }
        public int TotalPaginas { get; set; }
        public int TotalItens { get; set; }
        public IEnumerable<T> Data { get; set; }


        public ApiResponse() { }
        public ApiResponse(bool success, string message, List<string> erros, int paginaAtual, int itensPagina, int totalPaginas, int totalItens, IEnumerable<T> data)
        {
            Success = success;
            Message = message;
            Erros = erros ?? new List<string>();
            PaginaAtual = paginaAtual;
            ItensPagina = itensPagina;
            TotalPaginas = totalPaginas;
            TotalItens = totalItens;
            Data = data;
        }
    }
}
