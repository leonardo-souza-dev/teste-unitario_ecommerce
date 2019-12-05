using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Ecommerce.Domain.Entities
{
    public class Carrinho
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("produtos")]
        private List<Produto> Produtos { get; set; } = new List<Produto>();

        public void AdicionarProduto(Produto produto) => this.Produtos.Add(produto);
    }
}
