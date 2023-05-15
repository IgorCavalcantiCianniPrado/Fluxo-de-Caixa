using FluxoCaixa.DTOs;
using FluxoCaixa.Factories;
using FluxoCaixa.MessageBroker;
using FluxoCaixa.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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

        [HttpPost]
        [Route("Lancamento")]
        public IActionResult Lancamento(Lancamento lancamento)
        {
            try
            {
                var produtoCategoria = lancamento.produtoInfo.produtoCategoria;
                var produtoEspecificoNaCategoria = lancamento.produtoInfo.produtoEspecificoNaCategoria;

                var produtoFactory = CategoriaFactory.Create(produtoCategoria);

                var produto = produtoFactory.Create(produtoEspecificoNaCategoria);

                var valorTotalLancamento = new Calculadora().CalcularCreditoDebito(lancamento);

                //var lancamentoParaEnvio = new LancamentoParaEnvio(produto, valorTotalLancamento, lancamento.quantidade);
                var lancamentoParaEnvio = new LancamentoParaEnvio
                {
                   produto = produto,
                   valorTotal = valorTotalLancamento,
                   quantidade = lancamento.quantidade
                };

                //Aqui publicar no RabbitMQ o "lancamentoParaEnviar".
                //var publisher = new FluxoCaixaPublisher();
                //await publisher.Publish(lancamentoParaEnvio);

                publisher.Publish(lancamentoParaEnvio);
            }
            catch(Exception ex)
            {

            }    

            return Ok("Lançamento Realizado. Em breve o saldo será atualizado para futuros relatórios.");
        }
    }
}
