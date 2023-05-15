using FluxoCaixa.DTOs;
using FluxoCaixa.Enums;
using FluxoCaixa.Factories;
using FluxoCaixa.MessageBroker;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Repository;
using System;

namespace TestesUnitarios
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCategoriaFactoryFail()
        {
            var produtoCategoria = (ProdutoCategoria)15;

            try
            {
                var produto = CategoriaFactory.Create(produtoCategoria);
            }
            catch(Exception ex)
            {
                Assert.AreEqual("Categoria de produto inválida!", ex.Message);
            }           
        }

        [Test]
        public void TestCervejaFactoryFail()
        {
            var cervejaFactory = CategoriaFactory.Create(ProdutoCategoria.Cerveja);

            try
            {
                var cerveja = cervejaFactory.Create(75);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Tipo de cerveja inválido!", ex.Message);
            }
        }

        [Test]
        public void TestVinhoFactoryFail()
        {
            var vinhoFactory = CategoriaFactory.Create(ProdutoCategoria.Vinho);

            try
            {
                var vinho = vinhoFactory.Create(75);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Tipo de Uva inválido!", ex.Message);
            }
        }

        [Test]
        public void FluxoCaixaPublisherFail()
        {          
            try
            {
                var fluxoCaixaPublisher = new FluxoCaixaPublisher(null);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("O bus não pode ser nulo!", ex.Message);
            }
        }

        [Test]
        public void RepositoryConnectionStringFail()
        {
            var dataBaseMinimalData = new DataBaseMinimalData
            {
                ConnectionString = null,
                DataBase = "teste",
                CollectionName = "teste"
            };

            try
            {
                var dataBase = new Mongo(null, dataBaseMinimalData);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("A ConectionString não pode ser nula!", ex.Message);
            }
        }

        [Test]
        public void RepositoryDataBaseFail()
        {
            var dataBaseMinimalData = new DataBaseMinimalData
            {
                ConnectionString = "teste",
                DataBase = null,
                CollectionName = "teste"
            };

            try
            {
                var dataBase = new Mongo(null, dataBaseMinimalData);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("O DataBase não pode ser nulo!", ex.Message);
            }
        }

        [Test]
        public void RepositoryCollectionNameFail()
        {
            var dataBaseMinimalData = new DataBaseMinimalData
            {
                ConnectionString = "teste",
                DataBase = "teste",
                CollectionName = null
            };

            try
            {
                var dataBase = new Mongo(null, dataBaseMinimalData);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("A CollectionName não pode ser nulo!", ex.Message);
            }
        }
    }
}