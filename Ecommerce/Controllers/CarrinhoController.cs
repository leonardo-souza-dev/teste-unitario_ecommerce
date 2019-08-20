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
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private ICarrinhoService _carrinhoService;

        public CarrinhoController(ICarrinhoService carrinhoService)
        {
            _carrinhoService = carrinhoService;
        }
        
        [HttpPut()]
        public ActionResult<IncluirProdutoResponse> Put([FromBody]IncluirProdutoRequest request)
        {
            try
            {
                var resultado = _carrinhoService.AdicionarProdutoAoCarrinho(new Produto { IdProduto = request.IdProduto  }, request.IdCarrinho);

                return new IncluirProdutoResponse { Mensagem = resultado.Mensagem, Sucesso = true };
            }
            catch (Exception ex)
            {
                return new IncluirProdutoResponse { Mensagem = ex.ToString(), Sucesso = false };
            }
        }
    }
}
