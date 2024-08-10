using API_Avaliacao_Produtos_Servicos.Exceptions;
using API_Avaliacao_Produtos_Servicos.Models.Response;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;
using Newtonsoft.Json;

namespace API_Avaliacao_Produtos_Servicos.Middlewares

{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Variável para armazenar o código de status
            int statusCode = StatusCodes.Status500InternalServerError; // Status padrão para exceções genéricas

            // Verifica o tipo de exceção e ajusta o código de status e a mensagem conforme necessário
            if (exception is NotFoundException)
            {
                statusCode = StatusCodes.Status404NotFound;
            }
            else if (exception is BadRequestException)
            {
                statusCode = StatusCodes.Status400BadRequest;
            }

            // Cria uma nova instância de ErroResponse e preenche seus detalhes
            var respostaErro = new ErroResponse
            {
                Status = statusCode,
                Mensagem = exception.Message,
                Erros = new List<string> { exception.Message }
            };

            // Define o tipo de conteúdo e o status HTTP da resposta
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            // Serializa a resposta de erro para JSON e escreve na resposta HTTP
            return context.Response.WriteAsync(JsonConvert.SerializeObject(respostaErro));
        }
    }
}
