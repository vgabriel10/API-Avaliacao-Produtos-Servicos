using API_Avaliacao_Produtos_Servicos.Data;
using API_Avaliacao_Produtos_Servicos.Exceptions;
using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Repositories.Interfaces;
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

        public async Task<Usuario> AdicionarUsuario(Usuario usuario)
        {
            try
            {
                await _context.Usuarios.AddAsync(usuario);
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

        public async Task<IEnumerable<Usuario>> RetornarTodosUsuarios(int pagina = 1, int itensPagina = 20)
        {
            //// Garantir que o número da página e o tamanho sejam válidos
            //pagina = pagina < 1 ? 1 : pagina;
            //itensPagina = itensPagina < 1 ? 10 : itensPagina;

            //// Calcular quantos itens pular (skip)
            //int pular = (pagina - 1) * itensPagina;

            return await _context.Usuarios.Skip(pagina).Take(itensPagina).ToListAsync();
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
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
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
            //_context.Entry(usuarioExistente).CurrentValues.SetValues(usuario);

            usuarioExistente.Nome = usuario.Nome;
            usuarioExistente.Cpf = usuario.Cpf;
            usuarioExistente.Cidade = usuario.Cidade;
            usuarioExistente.DataNascimento = usuario.DataNascimento;
            usuarioExistente.DataCadastro = usuario.DataCadastro;
            usuarioExistente.Nacionalidade = usuario.Nacionalidade;

            // Salve as alterações
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
            return Task.FromResult(totalPaginas);
        }
    }
}
