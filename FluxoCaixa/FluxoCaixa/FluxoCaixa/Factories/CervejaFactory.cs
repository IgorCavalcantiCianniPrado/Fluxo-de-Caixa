using FluxoCaixa.Builders;
using FluxoCaixa.Enums;
using FluxoCaixa.Model;
using System;

namespace FluxoCaixa.Factories
{
    public class CervejaFactory : IProdutoFactory
    {
        public Produto Create(int produtoEspecificoNaCategoria)
        {
            var cervejaTipo = (CervejaTipo)produtoEspecificoNaCategoria;

            switch (cervejaTipo)
            {
                case CervejaTipo.Ipa:
                    var cervejaBuilder = new CervejaBuilder();

                    cervejaBuilder
                        .SetMarca("Colorado")
                        .SetDescricao("Traz a legítima fórmula utilizada pelos soldados ingleses em sua longa viagem marítima até a Índia.")
                        .SetDataFabricacao(new DateTime(2023, 01, 10))
                        .SetGraduacaoAlcoolica(7.0)
                        .SetNacionalidade(Nacionalidade.Brasil)
                        .SetTipo(cervejaTipo)
                        .SetIbu(45)
                        .SetDataValidade(new DateTime(2023, 12, 13));

                    return cervejaBuilder.Build();

                case CervejaTipo.Stout:
                    cervejaBuilder = new CervejaBuilder();

                    cervejaBuilder
                        .SetMarca("Schornstein")
                        .SetDescricao("")
                        .SetDataFabricacao(new DateTime(2023, 01, 10))
                        .SetGraduacaoAlcoolica(8.5)
                        .SetNacionalidade(Nacionalidade.Brasil)
                        .SetTipo(cervejaTipo)
                        .SetIbu(70)
                        .SetDataValidade(new DateTime(2023, 12, 13));

                    return cervejaBuilder.Build();

                case CervejaTipo.Porter:
                    cervejaBuilder = new CervejaBuilder();

                    cervejaBuilder
                        .SetMarca("Leopoldina")
                        .SetDescricao("")
                        .SetDataFabricacao(new DateTime(2023, 01, 10))
                        .SetGraduacaoAlcoolica(6.0)
                        .SetNacionalidade(Nacionalidade.Brasil)
                        .SetTipo(cervejaTipo)
                        .SetIbu(25)
                        .SetDataValidade(new DateTime(2023, 12, 13));

                    return cervejaBuilder.Build();

                case CervejaTipo.Witbier:
                    cervejaBuilder = new CervejaBuilder();

                    cervejaBuilder
                        .SetMarca("Hoegaarden")
                        .SetDescricao("")
                        .SetDataFabricacao(new DateTime(2023, 01, 10))
                        .SetGraduacaoAlcoolica(6.0)
                        .SetNacionalidade(Nacionalidade.Belgica)
                        .SetTipo(cervejaTipo)
                        .SetIbu(15)
                        .SetDataValidade(new DateTime(2023, 12, 13));

                    return cervejaBuilder.Build();

                default:
                    throw new Exception("Tipo de cerveja inválido!");
            }          
        }
    }
}
