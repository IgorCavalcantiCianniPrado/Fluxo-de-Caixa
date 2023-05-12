using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Relatorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        [HttpGet]
        public IActionResult SaldoConsolidado()
        {
            return Ok();
        }
    }
}
