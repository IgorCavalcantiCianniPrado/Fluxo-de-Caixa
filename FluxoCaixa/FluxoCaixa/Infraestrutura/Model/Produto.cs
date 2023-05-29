using Infraestrutura.Enums;
using System;

namespace Infraestrutura.Model
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
