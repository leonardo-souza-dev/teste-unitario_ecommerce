using NUnit.Framework;
using Ecommerce.Web.Controllers;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain;
using Ecommerce.Infrastructure.MongoDB;
using Ecommerce.Application.Impl;
using Ecommerce.Application.Messages;

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
            _carrinhoRepository = new CarrinhoRepository();
            _produtoRepository = new ProdutoRepository();
            _carrinhoService = new CarrinhoService(_carrinhoRepository, _produtoRepository);
        }

        [Test]
        [TestCase(1, 2, 3)]
        [TestCase(1, 12, null)]
        [TestCase(1, 100, null)]
        [TestCase(1, 1, 9944326)]
        public void Validar_Mensagem_Produto_incluido_com_sucesso(int idCliente, int idProduto, int? idCarrinho)
        {
            var controller = new CarrinhoController(_carrinhoService);
            var response = controller.Put(new IncluirProdutoRequest { IdProduto = idProduto, IdCarrinho = idCarrinho });

            var mensagem = response.Value.Mensagem;

            Assert.AreEqual("Produto incluído com sucesso", mensagem);
        }

        [Test]
        [TestCase(1, -1100, null)]
        [TestCase(1, -1, 9944326)]
        [TestCase(1, 101, 9944326)]
        public void Validar_Mensagem_Produto_nao_incluido(int idCliente, int idProduto, int? idCarrinho)
        {
            var controller = new CarrinhoController(_carrinhoService);
            var response = controller.Put(new IncluirProdutoRequest { IdProduto = idProduto, IdCarrinho = idCarrinho });

            var mensagem = response.Value.Mensagem;

            Assert.AreEqual("Produto não incluído", mensagem);
        }
    }
}