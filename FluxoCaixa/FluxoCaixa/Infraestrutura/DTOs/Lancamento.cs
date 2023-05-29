using Infraestrutura.Enums;

namespace Infraestrutura.DTOs
{
    public class Lancamento
    {
        public ProdutoInfo produtoInfo { get; set; }
        public LancamentoTipo lancamentoTipo { get; set; }
        public double valorVenda { get; set; }
        public double valorCompra { get; set; }
        public int quantidade { get; set; }
    }
}
