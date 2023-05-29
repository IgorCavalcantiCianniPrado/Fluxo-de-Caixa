using Infraestrutura.Model;

namespace Infraestrutura.Factories
{
    public interface IProdutoFactory
    {
        public Produto Create(int produtoEspecificoNaCategoria);
    }
}
