using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain
{
    public interface IProdutoRepository
    {
        Produto Obter(int idProduto);
    }
}