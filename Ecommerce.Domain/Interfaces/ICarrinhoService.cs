using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces
{
    public interface ICarrinhoService
    {
        Resultado<Carrinho> AdicionarProdutoAoCarrinho(Produto produto, int? idCarrinho);
    }
}
