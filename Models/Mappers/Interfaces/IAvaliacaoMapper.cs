using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;

namespace API_Avaliacao_Produtos_Servicos.Models.Mappers.Interfaces
{
    public interface IAvaliacaoMapper
    {
        Avaliacao ConverterParaEntidade (AvaliacaoInputModel inputModel);
        IEnumerable<Avaliacao> ConverterParaEntidade(IEnumerable<AvaliacaoInputModel> inputsModels);
        AvaliacaoViewModel ConverterParaViewModel (Avaliacao entidade);
        IEnumerable<AvaliacaoViewModel> ConverterParaViewModel(IEnumerable<Avaliacao> entidades);

    }
}
