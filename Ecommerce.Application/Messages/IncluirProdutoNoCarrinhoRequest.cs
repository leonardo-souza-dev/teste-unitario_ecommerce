﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Application.Messages
{
    public class IncluirProdutoNoCarrinhoRequest
    {
        public int IdProduto { get; set; }
        public int? IdCarrinho { get; set; }
    }
}