using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceProduct : IServiceProduct
    {
        private readonly IProduct _IProduct;

        public ServiceProduct(IProduct IProduct)
        {
            _IProduct = IProduct;
        }
        public async Task AddProduct(Produto produto)
        {
            var validaNome = produto.ValidarPropiedadeString(produto.Nome, "Nome");

            var ValidaValor = produto.ValidarPropiedadeDecimal(produto.Valor, "Valor");

            var ValidaQtdEstoque = produto.ValidarPropiedadeInt(produto.QtdEstoque, "QtdEstoque");

            if (validaNome && ValidaValor && ValidaQtdEstoque)
            {
                produto.DataCadastro = DateTime.Now;
                produto.DataAlteracao = DateTime.Now; 
                produto.Estado = true;
                await _IProduct.Add(produto);
            }
        }

        public async Task<List<Produto>> ListarProdutoComEstoque()
        {
            return await _IProduct.ListarProdutos(p => p.QtdEstoque > 0);
        }

        public async Task UpdateProduct(Produto produto)
        {
            var validaNome = produto.ValidarPropiedadeString(produto.Nome, "Nome");

            var ValidaValor = produto.ValidarPropiedadeDecimal(produto.Valor, "Valor");

            var ValidaQtdEstoque = produto.ValidarPropiedadeInt(produto.QtdEstoque, "QtdEstoque");

            if (validaNome && ValidaValor && ValidaQtdEstoque)
            {
                produto.DataAlteracao = DateTime.Now;

                await _IProduct.Update(produto);
            }
        }
    }
}
