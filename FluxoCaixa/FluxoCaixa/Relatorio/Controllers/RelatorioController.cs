using FluxoCaixa.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Linq;

namespace Relatorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        [Route("SaldoConsolidado")]
        [HttpGet]
        public IActionResult SaldoConsolidado()
        {
            var client = new MongoClient("mongodb://mongodbservice");
            //var client = new MongoClient("mongodb://localhost");

            var database = client.GetDatabase("FluxoCaixa");

            var produto = database.GetCollection<LancamentoParaEnvio>("CreditoDebito");

            var fields = Builders<LancamentoParaEnvio>.Projection.Include(p => p.valorTotal);

            var valorTotalLista = produto.Find(p => true).Project<LancamentoParaEnvio>(fields).ToList().Select(x => x.valorTotal);

            var saldoConsolidado = valorTotalLista.Sum(valor => valor);
            //var teste = produto.Find(p => true).ToList().AsQueryable();

            return Ok("Saldo Consolidado: " + saldoConsolidado);
        }
    }
}
