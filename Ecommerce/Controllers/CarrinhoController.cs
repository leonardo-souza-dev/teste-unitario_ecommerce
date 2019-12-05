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
    public class CarrinhoController : ControllerBase
    {
        private ICarrinhoService _carrinhoService;

        public CarrinhoController(ICarrinhoService carrinhoService)
        {
            _carrinhoService = carrinhoService;
        }
        
        [HttpPost("/adicionarProdutoAoCarrinho")]
        public ActionResult<IncluirProdutoNoCarrinhoResponse> AdicionarProdutoAoCarrinho([FromBody]IncluirProdutoNoCarrinhoRequest request)
        {
            try
            {
                var resultado = _carrinhoService.AdicionarProdutoAoCarrinho(new Produto { Id = request.IdProduto  }, request.IdCarrinho);

                return new IncluirProdutoNoCarrinhoResponse { Mensagem = resultado.Mensagem, Sucesso = true };
            }
            catch (Exception ex)
            {
                return new IncluirProdutoNoCarrinhoResponse { Mensagem = ex.ToString(), Sucesso = false };
            }
        }
    }
}
