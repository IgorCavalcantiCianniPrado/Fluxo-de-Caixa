using EasyNetQ;
using FluxoCaixa.DTOs;

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
            bus.PubSub.Publish(message);
        }
    }
}
