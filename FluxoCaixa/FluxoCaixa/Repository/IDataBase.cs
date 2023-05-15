using FluxoCaixa.DTOs;

namespace Repository
{
    public interface IDataBase
    {
        public void Insert(LancamentoParaEnvio lancamentoParaEnvio);
        public double GetSaldoConsolidado();
    }
}
