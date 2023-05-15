using FluxoCaixa.DTOs;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Worker.Repository
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
