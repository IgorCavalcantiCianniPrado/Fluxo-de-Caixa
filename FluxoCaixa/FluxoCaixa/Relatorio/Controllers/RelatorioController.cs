using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Repository;

namespace Relatorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IDataBase dataBase;

        public RelatorioController(IConfiguration configuration, IDataBase dataBase) 
        { 
            this.configuration = configuration;
            this.dataBase = dataBase;
        }

        [Authorize]
        [Route("SaldoConsolidado")]
        [HttpGet]
        public IActionResult SaldoConsolidado()
        {          
            var saldoConsolidado = dataBase.GetSaldoConsolidado();

            return Ok("Saldo Consolidado: " + saldoConsolidado);
        }
    }
}
