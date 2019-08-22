using Ecommerce.Domain;
using Ecommerce.Domain.Entities;
using MongoDB.Driver;

namespace Ecommerce.Infrastructure.MongoDB
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IMongoCollection<Produto> _produtos;

        public ProdutoRepository(IEcommerceDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _produtos = database.GetCollection<Produto>(settings.ProdutoCollectionName);
        }

        public Produto Inserir(Produto produto)
        {
            _produtos.InsertOne(produto);

            return produto;
        }

        public Produto Obter(int idProduto)
        {
            return _produtos.Find(x => x.IdProduto == idProduto).FirstOrDefault();
        }
    }
}
