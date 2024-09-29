using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;
using FluentValidation;

namespace API_Avaliacao_Produtos_Servicos.Validators
{
    public class CreateFornecedorValidator : AbstractValidator<CreateFornecedorInputModel>
    {
        public CreateFornecedorValidator() 
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .Length(3, 100);

            RuleFor(x => x.Cpf)
                .Length(11, 14);

            RuleFor(x => x.Cnpj)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Informe um CNPJ valido");

            RuleFor(x => x.Nacionalidade)
                .NotEmpty().WithMessage("Informe a nacionalidade do fornecedor");

        }
    }
}
