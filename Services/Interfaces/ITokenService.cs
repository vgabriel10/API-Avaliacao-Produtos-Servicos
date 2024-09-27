using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using System.Security.Claims;

namespace API_Avaliacao_Produtos_Servicos.Services.Interfaces
{
    public interface ITokenService
    {
        public string GerarToken(CreateUsuarioLoginInputModel usuario);

        public ClaimsIdentity GerarClaims(UsuarioLogin usuario);
    }
}
