using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Domain.Entities
{
    public class Carrinho
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("idCarrinho")]
        public int IdCarrinho { get; set; }

        private List<Produto> produtos { get; set; } = new List<Produto>();

        public Carrinho(int idCarrinho) => IdCarrinho = idCarrinho;

        public Carrinho() => IdCarrinho = new Random().Next(1, 100);

        public void AdicionarProduto(Produto produto) => this.produtos.Add(produto);

        public Produto ObterProduto(int idProduto) => this.produtos.First(x => x.IdProduto == idProduto);
    }
}
