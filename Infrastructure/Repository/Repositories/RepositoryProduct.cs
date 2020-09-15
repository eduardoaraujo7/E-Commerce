﻿using Domain.Interfaces.InterfaceProduct;
using Entities.Entities;
using Entities.Entities.Enums;
using Infrastructure.Configuartion;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryProduct : RepositoryGenerics<Produto>, IProduct
    {
        private readonly DbContextOptions<ContextBase> _optionsbuilder;
        public RepositoryProduct()
        {
            _optionsbuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Produto>> ListarProdutoCarrinhoUsuario(string userId)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                var produtoCarrinhoUsuario = await (from p in banco.Produto
                                                    join c in banco.CompraUsuario on p.Id equals c.IdProduto
                                                    where c.UserId.Equals(userId) && c.Estado == EnumEstadoCompra.Produto_Carrinho
                                                    select new Produto
                                                    {
                                                         Id = p.Id,
                                                         Nome = p.Nome,
                                                         Descricao = p.Descricao,
                                                         Observacao = p.Observacao,
                                                         Valor = p.Valor,
                                                         QtdCompra = c.QtdCompra,
                                                         IdProdutoCarrinho = c.Id,
                                                         Url = p.Url
                                                    }).AsNoTracking().ToListAsync();
                return produtoCarrinhoUsuario;
                
            }
                
        }

        public async Task<Produto> ObterProdutoCarrinho(int idProdutoCarrinho)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                var produtoCarrinhoUsuario = await(from p in banco.Produto
                                                   join c in banco.CompraUsuario on p.Id equals c.IdProduto
                                                   where c.Id.Equals(idProdutoCarrinho) && c.Estado == EnumEstadoCompra.Produto_Carrinho
                                                   select new Produto
                                                   {
                                                       Id = p.Id,
                                                       Nome = p.Nome,
                                                       Descricao = p.Descricao,
                                                       Observacao = p.Observacao,
                                                       Valor = p.Valor,
                                                       QtdCompra = c.QtdCompra,
                                                       IdProdutoCarrinho = c.Id,
                                                       Url = p.Url
                                                   }).AsNoTracking().FirstOrDefaultAsync();
                return produtoCarrinhoUsuario;

            }

        }

        public async Task<List<Produto>> ListarProdutos(Expression<Func<Produto, bool>> exProduto)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                return await banco.Produto.Where(exProduto).AsNoTracking().ToListAsync();
            }
        }

        public async Task<List<Produto>> ListarProdutoUsuario(string userId)
        {
            using(var banco = new ContextBase(_optionsbuilder))
            {
                return await banco.Produto.Where(p => p.UserId == userId).AsNoTracking().ToListAsync();
            }
        }

       
    }
}
