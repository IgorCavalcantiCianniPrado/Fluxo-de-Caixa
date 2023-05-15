using EasyNetQ;
using FluxoCaixa.DTOs;
using Worker.Repository;

namespace Worker.MessageBroker
{
    internal class FluxoCaixaConsumer : IConsumer
    {
        private readonly IBus bus;
        private readonly IDataBase dataBase;

        public FluxoCaixaConsumer(IBus bus, IDataBase dataBase)
        {
            this.bus = bus;
            this.dataBase = dataBase;

            this.bus.PubSub.Subscribe<LancamentoParaEnvio>("fluxoCaixa", Consume);
        }

        public void Consume(LancamentoParaEnvio lancamentoParaEnvio)
        {
            dataBase.Insert(lancamentoParaEnvio);   
        }
    }
}
