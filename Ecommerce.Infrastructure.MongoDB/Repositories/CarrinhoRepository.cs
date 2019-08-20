using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;

namespace Ecommerce.Infrastructure.MongoDB
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        public Carrinho Atualizar(Carrinho carrinho) =>
            carrinho;

        public Carrinho Obter(int? idCarrinho) =>
            idCarrinho.HasValue ? new Carrinho(idCarrinho.Value) : new Carrinho();
    }
}
