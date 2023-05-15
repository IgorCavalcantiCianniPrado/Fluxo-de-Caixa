using FluxoCaixa.DTOs;

namespace FluxoCaixa.MessageBroker
{
    public interface IPublisher
    {
        public void Publish(LancamentoParaEnvio message);
    }
}
