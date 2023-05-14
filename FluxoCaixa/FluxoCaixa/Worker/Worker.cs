using EasyNetQ;
using FluxoCaixa.DTOs;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Threading;
using System.Threading.Tasks;

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
            Console.WriteLine("Iniciou o Worker!!!");

            using (var bus = RabbitHutch.CreateBus("host=rabbitmqservice"))
            //using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.PubSub.Subscribe<LancamentoParaEnvio>("fluxoCaixa", Consumer);
                Thread.Sleep(Timeout.Infinite);
            }
        }

        public static void Consumer(LancamentoParaEnvio lancamentoParaEnvio)
        {
            Console.WriteLine("Consumiu a msg!!!");

            //IMongoCollection<LancamentoParaEnvio> mongoCollection;

            var client = new MongoClient("mongodb://mongodbservice");
            //var client = new MongoClient("mongodb://localhost");

            var database = client.GetDatabase("FluxoCaixa");

            var produto = database.GetCollection<LancamentoParaEnvio>("CreditoDebito");

            produto.InsertOne(lancamentoParaEnvio);
        }
    }
}
