using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Application.Messages;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Controllers
{
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        
        [HttpPut("/inserirProduto")]
        public ActionResult<IncluirProdutoNoCarrinhoResponse> InserirProduto([FromBody]InserirProdutoRequest request)
        {
            try
            {
                var resultado = _produtoService.Inserir(new Produto { Id = request.IdProduto });

                return new IncluirProdutoNoCarrinhoResponse { Mensagem = resultado.Mensagem, Sucesso = true };
            }
            catch (Exception ex)
            {
                return new IncluirProdutoNoCarrinhoResponse { Mensagem = ex.ToString(), Sucesso = false };
            }
        }
    }
}
