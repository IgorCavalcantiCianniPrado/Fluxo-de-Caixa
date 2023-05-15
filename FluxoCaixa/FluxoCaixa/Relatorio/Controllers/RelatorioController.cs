using FluxoCaixa.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Linq;

namespace Relatorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public RelatorioController(IConfiguration configuration) 
        { 
            this.configuration = configuration;
        }

        [Route("SaldoConsolidado")]
        [HttpGet]
        public IActionResult SaldoConsolidado()
        {
            var dataBaseConnectionString = configuration.GetConnectionString("DataBase");
            var dataBase = configuration.GetSection("DataBase:Name").Value;
            var collection = configuration.GetSection("DataBase:CollectionName").Value;

            var client = new MongoClient(dataBaseConnectionString);
            //var client = new MongoClient("mongodb://localhost");

            var database = client.GetDatabase(dataBase);

            var produto = database.GetCollection<LancamentoParaEnvio>(collection);

            var fields = Builders<LancamentoParaEnvio>.Projection.Include(p => p.valorTotal);

            var valorTotalLista = produto.Find(p => true).Project<LancamentoParaEnvio>(fields).ToList().Select(x => x.valorTotal);

            var saldoConsolidado = valorTotalLista.Sum(valor => valor);
            //var teste = produto.Find(p => true).ToList().AsQueryable();

            return Ok("Saldo Consolidado: " + saldoConsolidado);
        }
    }
}
