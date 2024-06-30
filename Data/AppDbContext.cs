﻿

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
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
                .HasMany(f => f.Produtos)
                .WithOne(p => p.Fornecedor);

            #endregion

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


            #endregion

            #region Categoria

            modelBuilder.Entity<Categoria>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Categoria>()
                .Property(x => x.Nome)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

            modelBuilder.Entity<Categoria>()
                .Property(x => x.Deletado)
                .HasColumnType("BOOLEAN");


            #endregion

        }
    }
}
