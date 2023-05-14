using FluxoCaixa.Model;
using MongoDB.Bson.Serialization.Attributes;

namespace FluxoCaixa.DTOs
{
    [BsonIgnoreExtraElements]
    public class LancamentoParaEnvio
    {
        public Produto produto { get; set; }
        public double valorTotal { get; set; }
        public int quantidade { get; set; }

        //public LancamentoParaEnvio(Produto produto, double valorTotal, int quantidade)
        //{
        //    this.produto = produto;
        //    this.valorTotal = valorTotal;
        //    this.quantidade = quantidade;   
        //}
    }
}
