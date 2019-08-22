using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces
{
    public interface IProdutoService
    {
        Resultado<Produto> Inserir(Produto produto);
        
    }
}
