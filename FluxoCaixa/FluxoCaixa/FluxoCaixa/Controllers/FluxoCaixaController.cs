using Infraestrutura.DTOs;
using Infraestrutura.Factories;
using MessageBroker.Publisher;
using Infraestrutura.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FluxoCaixaController : ControllerBase
    {
        private readonly IPublisher publisher;

        public FluxoCaixaController(IPublisher publisher)
        {
            this.publisher = publisher;
        }

        [Authorize]
        [HttpPost]
        [Route("Lancamento")]
        public IActionResult Lancamento(Lancamento lancamento)
        {
            var produtoCategoria = lancamento.produtoInfo.produtoCategoria;
            var produtoEspecificoNaCategoria = lancamento.produtoInfo.produtoEspecificoNaCategoria;

            var produtoFactory = CategoriaFactory.Create(produtoCategoria);

            var produto = produtoFactory.Create(produtoEspecificoNaCategoria);

            var valorTotalLancamento = new Calculadora().CalcularCreditoDebito(lancamento);

            var lancamentoParaEnvio = new LancamentoParaEnvio
            {
                produto = produto,
                valorTotal = valorTotalLancamento,
                quantidade = lancamento.quantidade
            };

            publisher.Publish(lancamentoParaEnvio);

            return Ok("Lançamento Realizado. Em breve o saldo será atualizado para futuros relatórios.");
        }
    }
}
