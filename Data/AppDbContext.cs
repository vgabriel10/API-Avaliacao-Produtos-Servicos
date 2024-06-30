

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
        //public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
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
                .HasForeignKey(x => x.FornecedorId);


            #endregion

            #region Usuarios
            modelBuilder.Entity<Usuario>()
               .HasKey(x => x.Id);

            // Adicionando autoIncrement 
            modelBuilder.Entity<Usuario>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

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
                .Property(x => x.Nacionalidade)
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

            //#region Comentarios
            //modelBuilder.Entity<Comentario>()
            //    .HasKey(x => x.Id);

            //modelBuilder.Entity<Comentario>()
            //    .Property(x => x.Titulo)
            //    .HasColumnType("VARCHAR")
            //    .HasMaxLength(100);

            //modelBuilder.Entity<Comentario>()
            //    .Property(x => x.Descricao)
            //    .HasColumnType("VARCHAR")
            //    .HasMaxLength(2000);

            //modelBuilder.Entity<Comentario>()
            //    .Property(x => x.Data)
            //    .HasColumnType("Timestamp without Time Zone");

            //// Um comentario está relacionado a um produto
            //// Um produto pode ter vários comentários
            //modelBuilder.Entity<Comentario>()
            //    .HasOne(c => c.Produto)
            //    .WithMany(p => p.Comentarios) // WithMany, indicando que um Produto pode ter muitos Comentarios
            //    .HasForeignKey(c => c.ProdutoId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Comentario>()
            //    .HasOne(c => c.Usuario)
            //    .WithMany(u => u.Comentarios)
            //    .HasForeignKey(c => c.UsuarioId)
            //    .OnDelete(DeleteBehavior.Cascade);


            //#endregion

            #region Avaliacoes

            modelBuilder.Entity<Avaliacao>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Avaliacao>()
                .Property(x => x.Nota)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20)
                .HasConversion<string>();

            modelBuilder.Entity<Avaliacao>()
                .HasOne(a => a.Produto)
                .WithMany(p => p.Avaliacoes)
                .HasForeignKey(a => a.ProdutoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Avaliacao>()
                .HasOne(a => a.Usuario)
                .WithMany(u => u.Avaliacoes)
                .HasForeignKey(a => a.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Avaliacao>()
            //    .HasOne(a => a.Comentario)
            //    .WithOne(c => c.Avaliacao)
            //    .HasForeignKey<Comentario>(c => c.AvaliacaoId)
            //    .OnDelete(DeleteBehavior.Cascade);


            #endregion
        }
    }
}
