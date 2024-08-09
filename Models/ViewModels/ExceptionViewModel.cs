namespace API_Avaliacao_Produtos_Servicos.Models.ViewModels
{
    public class ExceptionViewModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }

        public ExceptionViewModel(bool success = true, string message = null, List<string> errors = null)
        {
            Success = success;
            Message = message;
            Errors = errors ?? new List<string>();
        }
    }
}
