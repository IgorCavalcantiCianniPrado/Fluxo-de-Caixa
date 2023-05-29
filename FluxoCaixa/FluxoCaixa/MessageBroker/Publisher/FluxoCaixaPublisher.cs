using EasyNetQ;
using Infraestrutura.DTOs;
using System;

namespace MessageBroker.Publisher
{
    public class FluxoCaixaPublisher : IPublisher
    {
        private readonly IBus bus;

        public FluxoCaixaPublisher(IBus bus) 
        {
            if (bus is null)
                throw new Exception("O bus não pode ser nulo!");

            this.bus = bus;
        }

        public void Publish(LancamentoParaEnvio message)
        {
            bus.PubSub.Publish(message);
        }
    }
}
