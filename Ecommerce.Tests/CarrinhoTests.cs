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
        private IProdutoService _produtoService;

        private string _idProdutoTemp;

        [SetUp]
        public void Setup()
        {
            var settings = ObterSettings();
            _carrinhoRepository = new CarrinhoRepository(settings);
            _produtoRepository = new ProdutoRepository(settings);
            _carrinhoService = new CarrinhoService(_carrinhoRepository, _produtoRepository);
            _produtoService = new ProdutoService(_produtoRepository);
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

        [TearDown]
        public void Cleanup()
        {
            _produtoRepository.Remover(_idProdutoTemp);
        }

        [Test]
        [TestCase("12345678901234567890123a", null)]
        public void Validar_Mensagem_Produto_incluido_no_carrinho_com_sucesso(string idProduto, string idCarrinho)
        {
            //setup
            _idProdutoTemp = idProduto;
            _produtoRepository.Inserir(new Domain.Entities.Produto { Id = idProduto });
            //arrange
            var controller = new CarrinhoController(_carrinhoService);

            //act
            var response = controller.AdicionarProdutoAoCarrinho(new IncluirProdutoNoCarrinhoRequest { IdProduto = idProduto, IdCarrinho = idCarrinho });

            //assert
            Assert.AreEqual("Produto incluído no carrinho com sucesso", response.Value.Mensagem);
        }

        [Test]
        [TestCase("2891F050E489629A01C4021A", null)]
        [TestCase("91F050E489629A01C4021828", null)]
        [TestCase("9A01C40218291F050E489627", "C40050E4889629A01218291F")]
        [TestCase("629A01C40218291F050E4898", "C40050E4889629A01218291F")]
        public void Validar_Mensagem_Produto_nao_incluido_no_carrinho(string idProduto, string idCarrinho)
        {
            //arrange
            var controller = new CarrinhoController(_carrinhoService);

            //act
            var response = controller.AdicionarProdutoAoCarrinho(
                new IncluirProdutoNoCarrinhoRequest 
                { 
                    IdProduto = idProduto, 
                    IdCarrinho = idCarrinho 
                });

            //assert
            var mensagem = response.Value.Mensagem;

            Assert.AreEqual("Produto não incluído no carrinho", mensagem);
        }
    }
}