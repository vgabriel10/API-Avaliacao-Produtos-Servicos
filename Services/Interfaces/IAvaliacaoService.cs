﻿using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Services.Interfaces
{
    public interface IAvaliacaoService
    {
        Task<IEnumerable<AvaliacaoViewModel>> RetornaTodasAvaliacoes();
        Task<AvaliacaoViewModel> RetornaAvaliacaoPorId(int idAvaliacao);
        Task<IEnumerable<AvaliacaoViewModel>> RetornaAvaliacoesDoProduto(int idProduto);
        Task<AvaliacaoViewModel> AdicionarAvaliacao(CreateAvaliacaoInputModel avaliacao);
        Task<AvaliacaoViewModel> EditarAvaliacao(int idAvaliacao, UpdateAvaliacaoInputModel avalidacao);
        Task RemoverAvaliacao(int idAvaliacao);
    }
}
