using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Infrastructure.MongoDB
{
    public class EcommerceDatabaseSettings : IEcommerceDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        public string CarrinhoCollectionName { get; set; }
        public string ProdutoCollectionName { get; set; }
    }

    public interface IEcommerceDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

        string CarrinhoCollectionName { get; set; }
        string ProdutoCollectionName { get; set; }
    }
}
