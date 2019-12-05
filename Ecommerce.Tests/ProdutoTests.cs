using NUnit.Framework;
using Ecommerce.Web.Controllers;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain;
using Ecommerce.Infrastructure.MongoDB;
using Ecommerce.Application.Impl;
using Ecommerce.Application.Messages;
using Moq;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.Tests
{
    public class ProdutoTests
    {
        private IProdutoRepository _produtoRepository;
        private IProdutoService _produtoService;

        private string _idProdutoTemp;

        [SetUp]
        public void Setup()
        {
            var settings = ObterSettings();
            _produtoRepository = new ProdutoRepository(settings);
            _produtoService = new ProdutoService(_produtoRepository);
        }

        [TearDown]
        public void Cleanup()
        {
            _produtoRepository.Remover(_idProdutoTemp);
        }

        private static IEcommerceDatabaseSettings ObterSettings()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var settings = Mock.Of<IEcommerceDatabaseSettings>();
            settings.CarrinhoCollectionName = config.GetSection("EcommerceDatabaseSettings:CarrinhoCollectionName").Value;
            settings.ProdutoCollectionName = config.GetSection("EcommerceDatabaseSettings:ProdutoCollectionName").Value;
            settings.ConnectionString = config.GetSection("EcommerceDatabaseSettings:ConnectionString").Value;
            settings.DatabaseName = config.GetSection("EcommerceDatabaseSettings:DatabaseName").Value;
            return settings;
        }

        [Test]
        [TestCase("A29A01C40218291FE7898050")]
        public void Validar_Inserir_Produto(string idProduto)
        {
            //arrange
            var controller = new ProdutoController(_produtoService);
            _idProdutoTemp = idProduto;

            //act
            var response = controller.InserirProduto(new InserirProdutoRequest { IdProduto  = idProduto });

            //assert
            Assert.AreEqual("Produto incluído na base com sucesso", response.Value.Mensagem);

            //deleto
        }
    }
}