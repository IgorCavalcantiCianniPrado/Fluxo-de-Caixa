using Infraestrutura.Model;
using MongoDB.Bson.Serialization.Attributes;

namespace Infraestrutura.DTOs
{
    [BsonIgnoreExtraElements]
    public class LancamentoParaEnvio
    {
        public Produto produto { get; set; }
        public double valorTotal { get; set; }
        public int quantidade { get; set; }
    }
}
