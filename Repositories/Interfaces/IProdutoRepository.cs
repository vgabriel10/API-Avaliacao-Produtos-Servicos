using API_Avaliacao_Produtos_Servicos.Data;
using API_Avaliacao_Produtos_Servicos.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Avaliacao_Produtos_Servicos.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        public Task<IEnumerable<Produto>> FindAll();
        public Task<Produto> FindById(int id);
        public Task<Produto> Update();
        public Task DeleteById(int id);
    }
}
