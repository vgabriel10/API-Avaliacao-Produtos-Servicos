using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_Avaliacao_Produtos_Servicos.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ClaimsIdentity GerarClaims(UsuarioLogin usuario)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(
                new Claim(ClaimTypes.Email, usuario.Email));

            foreach (var role in usuario.UsuarioRoles)
            {
                ci.AddClaim(new Claim(ClaimTypes.Role, role.Role.Nome));
            }

            return ci;
        }

        public string GerarToken(UsuarioLogin usuario)
        {
            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var credenciais = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GerarClaims(usuario),
                SigningCredentials = credenciais,
                Expires = DateTime.UtcNow.AddHours(2),
                Audience = _configuration["Jwt:Audience"],
                Issuer = _configuration["Jwt:Issuer"]
            };

            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }
    }
}
