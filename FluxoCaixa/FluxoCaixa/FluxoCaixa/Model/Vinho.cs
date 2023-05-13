using FluxoCaixa.Enums;

namespace FluxoCaixa.Model
{
    public class Vinho : Produto
    {
        public string safra { get; set; }
        public UvaTipo uvaTipo { get; set; }
    }
}
