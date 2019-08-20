using Ecommerce.Application.Messages;
using Ecommerce.Domain;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Ecommerce.Application.Impl
{
    public class CarrinhoService : ICarrinhoService
    {
        ICarrinhoRepository _carrinhoRepository;
        IProdutoRepository _produtoRepository;

        public CarrinhoService(ICarrinhoRepository carrinhoRepository, IProdutoRepository produtoRepository)
        {
            _carrinhoRepository = carrinhoRepository;
            _produtoRepository = produtoRepository;
        }

        public Resultado<Carrinho> AdicionarProdutoAoCarrinho(Produto request, int? idCarrinho)
        {
            var carrinho = _carrinhoRepository.Obter(idCarrinho);
            var produto = _produtoRepository.Obter(request.IdProduto);

            var resultado = new Resultado<Carrinho>();

            if (carrinho != null && produto != null)
            {
                carrinho.AdicionarProduto(produto);

                var carrinhoAtualizado = _carrinhoRepository.Atualizar(carrinho);

                resultado.Mensagem = "Produto incluído com sucesso";
                resultado.Dado = carrinhoAtualizado;
                resultado.Sucesso = true;
            }
            else
            {
                resultado.Mensagem = "Produto não incluído";
                resultado.Sucesso = false;
            }

            return resultado;
        }
    }
}
