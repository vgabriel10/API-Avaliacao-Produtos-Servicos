using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using FluentValidation;

namespace API_Avaliacao_Produtos_Servicos.Validators
{
    public class UsuarioLoginValidator : AbstractValidator<UsuarioLoginInputModel>
    {
        public UsuarioLoginValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Informe o E-mail!")
                .EmailAddress()
                .WithMessage("E-mail inválido!");

            RuleFor(x => x.Senha)
                .NotEmpty()
                .WithMessage("Informe uma senha!")
                .MinimumLength(8)
                .WithMessage("A senha deve conter no mínimo 8 caracteres!");

        }
    }
}
