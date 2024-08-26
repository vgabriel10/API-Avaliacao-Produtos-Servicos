using API_Avaliacao_Produtos_Servicos.Models;
using System.Security.Claims;

namespace API_Avaliacao_Produtos_Servicos.Services.Interfaces
{
    public interface ITokenService
    {
        public string GerarToken(UsuarioLogin usuario);

        public ClaimsIdentity GerarClaims(UsuarioLogin usuario);
    }
}
