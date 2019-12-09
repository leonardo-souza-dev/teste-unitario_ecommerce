using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Application.Messages
{
    public class InserirProdutoRequest
    {
        public string IdProduto { get; set; }
        public string Descricao { get; set; }
    }
}
