using Infraestrutura.DTOs;

namespace MessageBroker.Consumer
{
    public interface IConsumer
    {
        public void Consume(LancamentoParaEnvio lancamentoParaEnvio);
    }
}
