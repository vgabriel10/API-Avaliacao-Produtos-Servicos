﻿using API_Avaliacao_Produtos_Servicos.Data;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Avaliacao_Produtos_Servicos.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context; 

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> AdicionarUsuario(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            return usuario;
        }

        public async Task<IEnumerable<Usuario>> RetornarTodosUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> BuscarUsuarioPorId(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (usuario != null)
            {
                return usuario;
            }

            return null;
        }

        public async Task DeletarUsuario(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.Id == id);
            if (usuario != null) 
            { 
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Usuario> EditarUsuario(int id, Usuario usuario)
        {
            var usuarioExistente = await _context.Usuarios.FindAsync(id);
            if (usuarioExistente == null)
                return null;

            // Atualize as propriedades da entidade existente com os valores do objeto fornecido
            _context.Entry(usuarioExistente).CurrentValues.SetValues(usuario);

            // Salve as alterações
            await _context.SaveChangesAsync();

            return usuarioExistente;
        }
    }
}
