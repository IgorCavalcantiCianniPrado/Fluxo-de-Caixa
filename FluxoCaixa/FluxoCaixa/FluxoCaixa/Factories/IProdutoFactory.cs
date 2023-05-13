using FluxoCaixa.Model;

namespace FluxoCaixa.Factories
{
    public interface IProdutoFactory
    {
        public Produto Create(int produtoEspecificoNaCategoria);
    }
}
