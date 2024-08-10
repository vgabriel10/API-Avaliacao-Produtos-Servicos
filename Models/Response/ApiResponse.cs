namespace API_Avaliacao_Produtos_Servicos.Models.Response
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }

        public ApiResponse(T data, bool success = true, string message = null, List<string> errors = null)
        {
            Success = success;
            Data = data;
            Message = message;
            Errors = errors ?? new List<string>();
        }
    }
}
