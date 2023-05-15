using FluxoCaixa.DTOs;
using System;
using System.Threading.Tasks;
using EasyNetQ;

namespace FluxoCaixa.MessageBroker
{
    public class FluxoCaixaPublisher : IPublisher
    {
        private readonly IBus bus;

        public FluxoCaixaPublisher(IBus bus) 
        { 
            this.bus = bus;
        }

        public void Publish(LancamentoParaEnvio message)
        {
            //using (var bus = RabbitHutch.CreateBus("host=rabbitmqservice"))
            //using (var bus = RabbitHutch.CreateBus("host=localhost"))
            //{
            bus.PubSub.Publish(message);
            //bus.Dispose();
            //}
        }
    }

    //public class FluxoCaixaPublisher : IPublisher
    //{
    //    public async Task Publish(LancamentoParaEnvio message) 
    //    {
    //        using (var bus = RabbitHutch.CreateBus("host=rabbitmqservice"))
    //        //using (var bus = RabbitHutch.CreateBus("host=localhost"))
    //        {
    //            bus.PubSub.Publish(message);
    //        }
    //    }
    //}
}
