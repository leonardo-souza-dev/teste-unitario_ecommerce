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
    public class CarrinhoTests
    {
        private ICarrinhoService _carrinhoService;
        private ICarrinhoRepository _carrinhoRepository;
        private IProdutoRepository _produtoRepository;

        [SetUp]
        public void Setup()
        {
            var settings = ObterSettings();

            _carrinhoRepository = new CarrinhoRepository(settings);
            _produtoRepository = new ProdutoRepository(settings);
            _carrinhoService = new CarrinhoService(_carrinhoRepository, _produtoRepository);
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
        [TestCase(1, 50, 3)]
        [TestCase(1, 12, null)]
        [TestCase(1, 100, null)]
        [TestCase(1, 1, 9944326)]
        public void Validar_Mensagem_Produto_incluido_no_carrinho_com_sucesso(int idCliente, int idProduto, int? idCarrinho)
        {
            var controller = new CarrinhoController(_carrinhoService);
            var response = controller.Put(new IncluirProdutoRequest { IdProduto = idProduto, IdCarrinho = idCarrinho });

            var mensagem = response.Value.Mensagem;

            Assert.AreEqual("Produto incluído no carrinho com sucesso", mensagem);
        }

        [Test]
        [TestCase(1, -1100, null)]
        [TestCase(1, -1, 9944326)]
        [TestCase(1, 101, 9944326)]
        public void Validar_Mensagem_Produto_nao_incluido_no_carrinho(int idCliente, int idProduto, int? idCarrinho)
        {
            var controller = new CarrinhoController(_carrinhoService);
            var response = controller.Put(new IncluirProdutoRequest { IdProduto = idProduto, IdCarrinho = idCarrinho });

            var mensagem = response.Value.Mensagem;

            Assert.AreEqual("Produto não incluído no carrinho", mensagem);
        }
    }
}