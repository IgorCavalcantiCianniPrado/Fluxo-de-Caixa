using Infraestrutura.Builders;
using Infraestrutura.Enums;
using Infraestrutura.Model;
using System;

namespace Infraestrutura.Factories
{
    public class VinhoFactory : IProdutoFactory
    {
        public Produto Create(int produtoEspecificoNaCategoria)
        {
            var uvaTipo = (UvaTipo)produtoEspecificoNaCategoria;

            switch (uvaTipo)
            {
                case UvaTipo.Montepulciano:
                    var vinhoBuilder = new VinhoBuilder();

                    vinhoBuilder
                        .SetMarca("Zolla")
                        .SetDescricao("")
                        .SetDataFabricacao(new DateTime(2023, 01, 10))
                        .SetGraduacaoAlcoolica(13.0)
                        .SetNacionalidade(Nacionalidade.Italia)
                        .SetSafra("2018")
                        .SetUva(uvaTipo);

                    return vinhoBuilder.Build();

                case UvaTipo.NeroDavola:
                    vinhoBuilder = new VinhoBuilder();

                    vinhoBuilder
                        .SetMarca("Zolla")
                        .SetDescricao("")
                        .SetDataFabricacao(new DateTime(2023, 01, 10))
                        .SetGraduacaoAlcoolica(14.0)
                        .SetNacionalidade(Nacionalidade.Italia)
                        .SetSafra("2018")
                        .SetUva(uvaTipo);

                    return vinhoBuilder.Build();

                case UvaTipo.Primitivo:
                    vinhoBuilder = new VinhoBuilder();

                    vinhoBuilder
                        .SetMarca("Zolla")
                        .SetDescricao("")
                        .SetDataFabricacao(new DateTime(2023, 01, 10))
                        .SetGraduacaoAlcoolica(14.0)
                        .SetNacionalidade(Nacionalidade.Italia)
                        .SetSafra("2018")
                        .SetUva(uvaTipo);

                    return vinhoBuilder.Build();

                case UvaTipo.CabernetSauvignon:
                    vinhoBuilder = new VinhoBuilder();

                    vinhoBuilder
                        .SetMarca("Reservado")
                        .SetDescricao("")
                        .SetDataFabricacao(new DateTime(2023, 01, 10))
                        .SetGraduacaoAlcoolica(14.0)
                        .SetNacionalidade(Nacionalidade.Brasil)
                        .SetSafra("2018")
                        .SetUva(uvaTipo);

                    return vinhoBuilder.Build();

                default:
                    throw new Exception("Tipo de Uva inválido!");
            }
        }
    }
}
