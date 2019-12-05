using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Application.Messages
{
    public class IncluirProdutoNoCarrinhoRequest
    {
        public string IdProduto { get; set; }
        public string IdCarrinho { get; set; }
    }
}
