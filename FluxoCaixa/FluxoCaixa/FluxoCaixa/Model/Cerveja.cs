using FluxoCaixa.Enums;
using System;

namespace FluxoCaixa.Model
{
    public class Cerveja : Produto
    {
        public CervejaTipo tipo { get; set; }
        public int ibu { get; set; }
        public DateTime dataValidade { get; set; }
    }
}
