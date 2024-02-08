

using API_Avaliacao_Produtos_Servicos.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Avaliacao_Produtos_Servicos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
    }
}
