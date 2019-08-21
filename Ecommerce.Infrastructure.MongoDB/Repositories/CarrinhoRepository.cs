using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using MongoDB.Driver;
using System.Linq;

namespace Ecommerce.Infrastructure.MongoDB
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly IMongoCollection<Carrinho> _carrinhos;

        public CarrinhoRepository(IEcommerceDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _carrinhos = database.GetCollection<Carrinho>(settings.CarrinhoCollectionName);
        }

        public Carrinho Atualizar(Carrinho carrinho)
        {
            return carrinho;
        }

        public Carrinho Inserir(Carrinho carrinho)
        {
            _carrinhos.InsertOne(carrinho);

            return carrinho;
        }

        public Carrinho Obter(int idCarrinho)
        {
            return _carrinhos.Find(x => x.IdCarrinho == idCarrinho).FirstOrDefault();
        }
    }
}
