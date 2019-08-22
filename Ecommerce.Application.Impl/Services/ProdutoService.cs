using Ecommerce.Application.Messages;
using Ecommerce.Domain;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Ecommerce.Application.Impl
{
    public class ProdutoService : IProdutoService
    {
        IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public Resultado<Produto> Inserir(Produto produto)
        {
             _produtoRepository.Inserir(produto);

            var resultado = new Resultado<Produto>
            {
                Mensagem = "Produto incluído na base com sucesso",
                Dado = produto,
                Sucesso = true
            };

            return resultado;
        }
    }
}
