using EasyNetQ;
using FluxoCaixa.DTOs;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

using MongoDB;
using MongoDB.Driver;
using System;

namespace Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.PubSub.Subscribe<LancamentoParaEnvio>("fluxoCaixa", Consumer);
                Console.ReadLine();
            }
        }

        public static void Consumer(LancamentoParaEnvio lancamentoParaEnvio)
        {
            //IMongoCollection<LancamentoParaEnvio> mongoCollection;

            var client = new MongoClient("mongodb://localhost:27017");

            var database = client.GetDatabase("FluxoCaixa");

            var produto = database.GetCollection<LancamentoParaEnvio>("CreditoDebito");

            produto.InsertOne(lancamentoParaEnvio);
        }
    }
}
