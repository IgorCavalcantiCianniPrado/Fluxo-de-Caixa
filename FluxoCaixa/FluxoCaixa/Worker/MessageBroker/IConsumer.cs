using FluxoCaixa.DTOs;

namespace Worker.MessageBroker
{
    public interface IConsumer
    {
        public void Consume(LancamentoParaEnvio lancamentoParaEnvio);
    }
}
