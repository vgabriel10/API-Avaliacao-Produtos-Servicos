﻿using API_Avaliacao_Produtos_Servicos.Models.InputModels;
using API_Avaliacao_Produtos_Servicos.Models.ViewModels;
using FluentValidation;

namespace API_Avaliacao_Produtos_Servicos.Validators
{
    public class ProdutoValidator : AbstractValidator<ProdutoInputModel>
    {
        public ProdutoValidator() 
        {
            

        }
    }
}
