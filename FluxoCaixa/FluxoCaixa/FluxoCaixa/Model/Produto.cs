using FluxoCaixa.Enums;
using System;

namespace FluxoCaixa.Model
{
    public abstract class Produto
    {
        public string marca;
        public string descricao;
        public DateTime dataFabricacao;
        public double graduacaoAlcoolica;
        public Nacionalidade nacionalidade;
    }
}
