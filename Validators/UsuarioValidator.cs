using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;
using FluentValidation;

namespace API_Avaliacao_Produtos_Servicos.Validators
{
    public class UsuarioValidator : AbstractValidator<UsuarioInputModel>
    {
        public UsuarioValidator() 
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .Length(3, 100).WithMessage("O nome deve ter pelo menos 3 caracteres e no máximo 100");

            RuleFor(x => x.DataNascimento)
                .NotEmpty()
                .LessThan(DateTime.Now).WithMessage("A data de nascimento deve ser menor que hoje");

            RuleFor(x => x.Cpf)
                .NotEmpty()
                .Length(11, 14);
            

        }
    }
}
