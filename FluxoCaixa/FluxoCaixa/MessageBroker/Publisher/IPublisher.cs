using Infraestrutura.DTOs;

namespace MessageBroker.Publisher
{
    public interface IPublisher
    {
        public void Publish(LancamentoParaEnvio message);
    }
}
