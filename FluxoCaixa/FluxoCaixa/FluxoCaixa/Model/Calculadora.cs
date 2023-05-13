using FluxoCaixa.DTOs;
using FluxoCaixa.Enums;

namespace FluxoCaixa.Model
{
    public class Calculadora
    {
        private LancamentoTipo lancamentoTipo;
        private double valorVenda;
        private double valorCompra;
        private int quantidade;

        public double CalcularCreditoDebito(Lancamento lancamento)
        {
            InicializaPropriedades(lancamento);

            var valor = lancamentoTipo == LancamentoTipo.Credito ? valorVenda : valorCompra;

            return valor * quantidade;
        }

        private void InicializaPropriedades(Lancamento lancamento)
        {
            lancamentoTipo = lancamento.lancamentoTipo;
            valorVenda = lancamento.valorVenda;
            valorCompra = (-1) * lancamento.valorCompra;
            quantidade = lancamento.quantidade;
        }
    }
}
