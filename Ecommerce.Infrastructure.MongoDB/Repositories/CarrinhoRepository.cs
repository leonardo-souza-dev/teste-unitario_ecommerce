using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using MongoDB.Bson;
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

        public Carrinho Inserir(Carrinho carrinho)
        {
            _carrinhos.InsertOne(carrinho);

            return carrinho;
        }

        public Carrinho Obter(string id)
        {
            return _carrinhos.Find(x => x.Id == id).FirstOrDefault();
        }

        public Carrinho Atualizar(Carrinho carrinho)
        {
            _carrinhos.ReplaceOne(c => c.Id == carrinho.Id, carrinho);

            return carrinho;
        }
    }
}
