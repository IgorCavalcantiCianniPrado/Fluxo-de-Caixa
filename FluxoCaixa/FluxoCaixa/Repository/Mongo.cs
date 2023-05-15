using FluxoCaixa.DTOs;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Linq;

namespace Repository
{
    public class Mongo : IDataBase
    {
        private static IMongoCollection<LancamentoParaEnvio> collection;

        public Mongo(IConfiguration configuration)
        {
            ConfigureDataBase(configuration);
        }

        public void Insert(LancamentoParaEnvio lancamentoParaEnvio)
        {
            collection.InsertOne(lancamentoParaEnvio);
        }

        public double GetSaldoConsolidado()
        {
            var fields = Builders<LancamentoParaEnvio>.Projection.Include(p => p.valorTotal);

            var valorTotalLista = collection
                                    .Find(p => true)
                                    .Project<LancamentoParaEnvio>(fields)
                                    .ToList()
                                    .Select(x => x.valorTotal);

            var saldoConsolidado = valorTotalLista.Sum(valor => valor);

            return saldoConsolidado;
        }

        private static void ConfigureDataBase(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DataBase");
            var dataBase = configuration.GetSection("DataBase:Name").Value;
            var collectionName = configuration.GetSection("DataBase:CollectionName").Value;

            var client = new MongoClient(connectionString);

            var database = client.GetDatabase(dataBase);

            collection = database.GetCollection<LancamentoParaEnvio>(collectionName);
        }  
    }
}
