using API_Avaliacao_Produtos_Servicos.Data;

namespace API_Avaliacao_Produtos_Servicos.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        public void FindAll();
        public void FindById(int Id);
    }
}
