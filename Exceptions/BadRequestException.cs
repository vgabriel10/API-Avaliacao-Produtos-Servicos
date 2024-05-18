namespace API_Avaliacao_Produtos_Servicos.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message) { }
    }
}
