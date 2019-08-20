using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces
{
    public interface ICarrinhoRepository
    {
        Carrinho Atualizar(Carrinho carrinho);
        Carrinho Obter(int? idCarrinho);
    }
}
