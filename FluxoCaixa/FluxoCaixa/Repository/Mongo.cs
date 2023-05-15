using FluxoCaixa.DTOs;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Linq;

namespace Repository
{
    public class Mongo : IDataBase
    {
        private static IMongoCollection<LancamentoParaEnvio> collection;
        private static DataBaseMinimalData dataBaseMinimalData;

        public Mongo(IConfiguration configuration, DataBaseMinimalData dataBaseMinimalDataArg)
        {
            if (dataBaseMinimalDataArg.ConnectionString is null)
                throw new Exception("A ConectionString não pode ser nula!");

            if (dataBaseMinimalDataArg.DataBase is null)
                throw new Exception("O DataBase não pode ser nulo!");

            if (dataBaseMinimalDataArg.CollectionName is null)
                throw new Exception("A CollectionName não pode ser nulo!");

            dataBaseMinimalData = dataBaseMinimalDataArg;

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
            var client = new MongoClient(dataBaseMinimalData.ConnectionString);

            var database = client.GetDatabase(dataBaseMinimalData.DataBase);

            collection = database.GetCollection<LancamentoParaEnvio>(dataBaseMinimalData.CollectionName);
        }  
    }
}
