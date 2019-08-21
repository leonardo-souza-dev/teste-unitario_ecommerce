using Ecommerce.Domain;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Infrastructure.MongoDB
{
    public class ProdutoRepository : IProdutoRepository
    {
        public Produto Obter(int idProduto)
        {
            return idProduto >= 1 && idProduto <= 100 ? new Produto { IdProduto = idProduto } : null;
        }
    }
}
