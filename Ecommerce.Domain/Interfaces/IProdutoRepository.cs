using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain
{
    public interface IProdutoRepository
    {
        Produto Inserir(Produto produto);
        Produto Obter(string idProduto);
        void Remover(string idProduto);
    }
}