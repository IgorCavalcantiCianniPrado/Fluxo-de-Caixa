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
        private readonly IDataBase database;

        public RelatorioController(IConfiguration configuration, IDataBase dataBase) 
        { 
            this.configuration = configuration;
            this.database = dataBase;
        }

        [Route("SaldoConsolidado")]
        [HttpGet]
        public IActionResult SaldoConsolidado()
        {          
            var saldoConsolidado = database.GetSaldoConsolidado();

            return Ok("Saldo Consolidado: " + saldoConsolidado);
        }
    }
}
