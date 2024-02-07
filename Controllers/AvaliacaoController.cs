using API_Avaliacao_Produtos_Servicos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace API_Avaliacao_Produtos_Servicos.Controllers
{
    [ApiController]
    [Route(template: "api/v1")]
    public class AvaliacaoController : ControllerBase
    {
        public AvaliacaoController()
        {

        }


        [HttpGet]
        [Route(template: "getAllAvaliacoes")]
        public async Task<IEnumerable<Produto>> GetAllAvaliacoes()
        {
            IEnumerable<Produto> produtos = new List<Produto>
            {
                new Produto { Id = 1, Nome = "Smartphone", Avaliacao = 5, Descricao = "Tela de alta resolução, processador rápido, câmera de alta qualidade, conectividade 5G." },
                new Produto { Id = 2, Nome = "Laptop", Avaliacao = 4, Descricao = "Processador potente, tela de alta definição, bateria de longa duração, armazenamento SSD rápido." },
                new Produto { Id = 3, Nome = "Fone de Ouvido Bluetooth", Avaliacao = 4, Descricao = "Cancelamento de ruído ativo, conexão Bluetooth estável, longa duração da bateria, qualidade de som premium." },
                new Produto { Id = 4, Nome = "Máquina de Café Expresso", Avaliacao = 4, Descricao = "Pressão adequada para extração, função de espuma de leite, opções de café personalizadas." },
                new Produto { Id = 5, Nome = "Drone", Avaliacao = 4, Descricao = "Câmera de alta resolução, estabilização avançada, controles intuitivos, longo alcance de voo." },
                new Produto { Id = 6, Nome = "Relógio Inteligente (Smartwatch)", Avaliacao = 4, Descricao = "Monitoramento de saúde, GPS integrado, notificações de smartphone, resistência à água." },
                new Produto { Id = 7, Nome = "Caixa de Som Bluetooth Portátil", Avaliacao = 4, Descricao = "Qualidade de som nítida, conexão Bluetooth fácil, resistente à água e poeira." },
                new Produto { Id = 8, Nome = "Câmera DSLR", Avaliacao = 4, Descricao = "Sensor de alta resolução, capacidade para troca de lentes, controles manuais avançados." },
                new Produto { Id = 9, Nome = "Patinete Elétrico", Avaliacao = 4, Descricao = "Velocidade máxima adequada, autonomia de bateria suficiente, design dobrável e portátil." },
                new Produto { Id = 10, Nome = "Impressora Multifuncional", Avaliacao = 4, Descricao = "Impressão de alta qualidade, scanner de documentos rápido, conexão Wi-Fi para impressão sem fio." }
            };

            return await Task.FromResult(produtos); ;
        }

        //public async Task<IActionResult> GetByIdProduto()
        //{
        //    return null;
        //}

    }
}
