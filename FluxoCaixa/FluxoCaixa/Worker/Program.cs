using EasyNetQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Worker.MessageBroker;
using Worker.Repository;

namespace Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();

                    var configuration = hostContext.Configuration;

                    ConfigureMessageBroker(services, configuration);
                });

        private static void ConfigureMessageBroker(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MessageBroker");

            var bus = RabbitHutch.CreateBus(connectionString);

            var dataBase = GetDataBase(configuration);

            services.AddSingleton(bus);
            services.AddSingleton(dataBase);

            services.AddSingleton<IConsumer>(new FluxoCaixaConsumer(bus, dataBase));
        }

        private static IDataBase GetDataBase(IConfiguration configuration)
        {
            IDataBase dataBase = new Mongo(configuration);

            return dataBase;
        }
    }
}
