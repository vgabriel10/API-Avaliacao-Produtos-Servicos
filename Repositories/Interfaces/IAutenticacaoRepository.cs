﻿using API_Avaliacao_Produtos_Servicos.Models;
using API_Avaliacao_Produtos_Servicos.Models.InputModels;

namespace API_Avaliacao_Produtos_Servicos.Repositories.Interfaces
{
    public interface IAutenticacaoRepository
    {
        Task<UsuarioLogin> CadastrarUsuario(UsuarioLogin usuarioLogin); 
    }
}
