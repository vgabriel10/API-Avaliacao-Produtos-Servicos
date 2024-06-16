using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;
using FluentValidation;

namespace API_Avaliacao_Produtos_Servicos.Validators
{
    public class ProdutoValidator : AbstractValidator<CreateProdutoInputModel>
    {
        public ProdutoValidator() 
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Informe o nome do produto")
                .Length(3, 100).WithMessage("O produto deve ter entre 3 e 100 caracteres");

            RuleFor(x => x.Preco)
                .NotEmpty().WithMessage("O produto deve ter um preço")
                .GreaterThan(0).WithMessage("O preço deve ser maior que zero");

            

            //RuleFor(x => x.FornecedorId)
            //    .NotEmpty().WithMessage("Informe o id do fornecedor do produto")
            //    .Must(dado => Numero(dado).WithMessage("O Id do fornecedor deve ser um número")

        }

    }
}
