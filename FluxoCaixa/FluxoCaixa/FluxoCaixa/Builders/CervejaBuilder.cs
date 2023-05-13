using FluxoCaixa.Enums;
using FluxoCaixa.Model;
using System;

namespace FluxoCaixa.Builders
{
    public class CervejaBuilder
    {
        /*
         
            public abstract class Produto
    {
    }
         
         */



        private Cerveja cerveja;

        public CervejaBuilder() 
        { 
            cerveja = new Cerveja();
        }

        public CervejaBuilder SetMarca(string marca)
        {
            cerveja.marca = marca;

            return this;
        }

        public CervejaBuilder SetDescricao(string descricao)
        {
            cerveja.descricao = descricao;

            return this;
        }

        public CervejaBuilder SetDataFabricacao(DateTime dataFabricacao)
        {
            cerveja.dataFabricacao = dataFabricacao;

            return this;
        }

        public CervejaBuilder SetGraduacaoAlcoolica(double graduacaoAlcoolica)
        {
            cerveja.graduacaoAlcoolica = graduacaoAlcoolica;

            return this;
        }

        public CervejaBuilder SetNacionalidade(Nacionalidade nacionalidade)
        {
            cerveja.nacionalidade = nacionalidade;

            return this;
        }

        public CervejaBuilder SetTipo(CervejaTipo tipo)
        {
            cerveja.tipo = tipo;

            return this;
        }

        public CervejaBuilder SetIbu(int ibu)
        {
            cerveja.ibu = ibu;  

            return this;
        }

        public CervejaBuilder SetDataValidade(DateTime dataValidade)
        {
            cerveja.dataValidade = dataValidade;    

            return this;
        }

        public Cerveja Build() 
        {
            return cerveja;
        }
    }
}
