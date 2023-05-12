using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FluxoCaixaController : ControllerBase
    {
        [HttpPost]
        public IActionResult Debito()
        {
            return Ok("Débito realizado.");
        }

        [HttpPost]
        public IActionResult Credito()
        {
            return Ok("Crédito realizado.");
        }
    }
}
