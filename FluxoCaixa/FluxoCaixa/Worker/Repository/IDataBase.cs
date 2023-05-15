using FluxoCaixa.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Worker.Repository
{
    public interface IDataBase
    {
        public void Insert(LancamentoParaEnvio lancamentoParaEnvio);
    }
}
