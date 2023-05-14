using FluxoCaixa.DTOs;
using System;
using System.Threading.Tasks;
using EasyNetQ;

namespace FluxoCaixa.MessageBroker
{
    public class FluxoCaixaPublisher
    {
        public async Task Publish(LancamentoParaEnvio message) 
        {
            using (var bus = RabbitHutch.CreateBus("host=rabbitmqservice"))
            //using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.PubSub.Publish(message);
            }
        }
    }
}
