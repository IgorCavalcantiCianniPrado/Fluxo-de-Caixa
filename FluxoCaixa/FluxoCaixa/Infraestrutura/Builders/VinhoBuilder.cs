using Infraestrutura.Enums;
using Infraestrutura.Model;
using System;

namespace Infraestrutura.Builders
{
    public class VinhoBuilder
    {
        private Vinho vinho;

        public VinhoBuilder()
        {
            this.vinho = new Vinho();
        }

        public VinhoBuilder SetMarca(string marca)
        {
            vinho.marca = marca;

            return this;
        }

        public VinhoBuilder SetDescricao(string descricao)
        {
            vinho.descricao = descricao;

            return this;
        }

        public VinhoBuilder SetDataFabricacao(DateTime dataFabricacao)
        {
            vinho.dataFabricacao = dataFabricacao;

            return this;
        }

        public VinhoBuilder SetGraduacaoAlcoolica(double graduacaoAlcoolica)
        {
            vinho.graduacaoAlcoolica = graduacaoAlcoolica;

            return this;
        }

        public VinhoBuilder SetNacionalidade(Nacionalidade nacionalidade)
        {
            vinho.nacionalidade = nacionalidade;

            return this;
        }

        public VinhoBuilder SetSafra(string safra)
        {
            vinho.safra = safra;

            return this;
        }

        public VinhoBuilder SetUva(UvaTipo uvaTipo)
        {
            vinho.uvaTipo = uvaTipo;

            return this;
        }

        public Vinho Build()
        {
            return vinho;
        }
    }
}
