

using API_Avaliacao_Produtos_Servicos.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace API_Avaliacao_Produtos_Servicos.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definindo a chave primaria de produto
            //modelBuilder.Entity<Produto>(x =>
            //{
            //    x.HasKey(x => x.Id);
            //    x.Property(x => x.Nome).HasMaxLength(50);
            //    x.HasOne(x => x.Avaliacoes);
            //});

            #region Produtos

            modelBuilder.Entity<Produto>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<Produto>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Produto>()
                .Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            modelBuilder.Entity<Produto>()
                .Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("TEXT");
            
         

            modelBuilder.Entity<Produto>()
                .HasOne(x => x.Fornecedor)
                .WithMany()
                .HasForeignKey(x => x.FornecedorID);


            #endregion

            #region Usuarios
            modelBuilder.Entity<Usuario>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<Usuario>()
                .Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            modelBuilder.Entity<Usuario>()
                .Property(x => x.Nacionalidade)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

            modelBuilder.Entity<Usuario>()
                .Property(x => x.Cidade)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

            modelBuilder.Entity<Usuario>()
                .Property(x => x.DataCadastro)
                .HasColumnType("Timestamp without Time Zone");

            modelBuilder.Entity<Usuario>()
                .Property(x => x.DataNascimento)
                .HasColumnType("Timestamp without Time Zone");

            modelBuilder.Entity<Usuario>()
                .Property(x => x.Cpf)
                .HasColumnType("VARCHAR")
                .HasMaxLength(14);

            modelBuilder.Entity<Usuario>()
                .Property(x => x.Deletado)
                .HasColumnType("BOOLEAN");
            

            #endregion

            #region Fornecedores
            modelBuilder.Entity<Fornecedor>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Fornecedor>()
                .Property(x => x.Pais)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

            modelBuilder.Entity<Fornecedor>()
                .Property(x => x.Cidade)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

            modelBuilder.Entity<Fornecedor>()
                .Property(x => x.Cpf)
                .HasColumnType("VARCHAR")
                .HasMaxLength(14);

            modelBuilder.Entity<Fornecedor>()
                .Property(x => x.Cnpj)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

            modelBuilder.Entity<Fornecedor>()
                .Property(x => x.DataCadastro)
                .HasColumnType("Timestamp without Time Zone");

            modelBuilder.Entity<Fornecedor>()
                .Property(x => x.Deletado)
                .HasColumnType("BOOLEAN");

            modelBuilder.Entity<Fornecedor>()
                .HasMany(x => x.Produtos)
                .WithOne();

            #endregion

            #region Comentarios

            #endregion
        }
    }
}
