using Infraestrutura.Enums;
using System;

namespace Infraestrutura.Factories
{
    public class CategoriaFactory
    {
        public static IProdutoFactory Create(ProdutoCategoria produtoCategoria)
        {
            switch (produtoCategoria)
            {
                case ProdutoCategoria.Cerveja:
                    return new CervejaFactory();

                case ProdutoCategoria.Vinho:
                    return new VinhoFactory();

                default:
                    throw new Exception("Categoria de produto inválida!");
            }
        }
    }
}
