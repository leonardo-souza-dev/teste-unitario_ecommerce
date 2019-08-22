using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Application.Messages
{
    public class IncluirProdutoNoCarrinhoResponse
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
    }
}
