using API_Avaliacao_Produtos_Servicos.Data;
using API_Avaliacao_Produtos_Servicos.Exceptions;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace API_Avaliacao_Produtos_Servicos.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context; 

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public async Task<Usuario> AdicionarUsuario(Usuario usuario, int usuarioLoginId)
        {
            try
            {
                await _context.Usuarios.AddAsync(usuario);                
                await _context.SaveChangesAsync();
                var usuarioLogin = await _context.UsuariosLogin.FirstOrDefaultAsync(x => x.Id == usuarioLoginId);
                usuarioLogin.UsuarioId = usuario.Id;
                await _context.SaveChangesAsync();
                return usuario;
            }
            catch (PostgresException ex) when (ex.SqlState == "23505")
            {
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }

        [Authorize]
        public async Task<IEnumerable<Usuario>> RetornarTodosUsuarios(int pagina = 1, int itensPagina = 20)
        {
            return await _context.Usuarios.Where(x => x.Deletado == false).Skip(pagina).Take(itensPagina).ToListAsync();
        }

        [Authorize]
        public async Task<Usuario> BuscarUsuarioPorId(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id && x.Deletado == false);
            if (usuario != null)
            {
                return usuario;
            }

            return null;
        }

        [Authorize("Admin")]
        public async Task DeletarUsuario(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (usuario != null) 
            {
                usuario.Deletado = true;
                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();
            }
        }

        [Authorize]
        public async Task<Usuario> EditarUsuario(int id, Usuario usuario)
        {
            var usuarioExistente = await _context.Usuarios.FindAsync(id);
            if (usuarioExistente == null)
                return null;

            usuarioExistente.Nome = usuario.Nome;
            usuarioExistente.Cpf = usuario.Cpf;
            usuarioExistente.Cidade = usuario.Cidade;
            usuarioExistente.DataNascimento = usuario.DataNascimento;
            usuarioExistente.DataCadastro = usuario.DataCadastro;
            usuarioExistente.Nacionalidade = usuario.Nacionalidade;

            await _context.SaveChangesAsync();

            return usuarioExistente;
        }

        public async Task<int> QuantidadeUsuariosAtivos()
        {
            return await _context.Usuarios.CountAsync(x => !x.Deletado);
        }

        public Task<int> QuantidadePaginas(int totalRegistros, int itensPagina)
        {
            int totalPaginas = (int)Math.Ceiling((double)totalRegistros / itensPagina);
            if (totalPaginas < 0)
                totalPaginas = 1;
            return Task.FromResult(totalPaginas);
        }
    }
}
