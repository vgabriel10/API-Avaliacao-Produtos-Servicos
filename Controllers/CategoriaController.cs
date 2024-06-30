using Microsoft.AspNetCore.Mvc;

namespace API_Avaliacao_Produtos_Servicos.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class CategoriaController : Controller
    {

        public async Task<IActionResult> Get()
        {
            return View();
        }
    }
}
