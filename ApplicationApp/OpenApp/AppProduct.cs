using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppProduct : InterfaceProductApp
    {
        IProduct _IProduct;
        IServiceProduct _IServiceProduct;
        public AppProduct(IProduct IProduct, IServiceProduct IServiceProduct)
        {
            _IProduct = IProduct;
            _IServiceProduct = IServiceProduct;
        }

        public async Task<List<Produto>> ListarProdutoCarrinhoUsuario(string userId)
        {
            return await _IProduct.ListarProdutoCarrinhoUsuario(userId);
        }

        public async Task<Produto> ObterProdutoCarrinho(int idProdutoCarrinho)
        {
            return await _IProduct.ObterProdutoCarrinho(idProdutoCarrinho);
        }

        public async Task AddProduct(Produto produto)
        {
            await _IServiceProduct.AddProduct(produto);
        }

        public async Task UpdateProduct(Produto produto)
        {
            await _IServiceProduct.UpdateProduct(produto);
        }
        public async Task<List<Produto>> ListarProdutoUsuario(string userId)
        {
            return await _IProduct.ListarProdutoUsuario(userId);
        }

        public async Task Add(Produto Objeto)
        {
            await _IProduct.Add(Objeto);
        }

        public async Task Delete(Produto Objeto)
        {
            await _IProduct.Delete(Objeto);
        }

        public async Task<Produto> GetEntityById(int Id)
        {
           return await _IProduct.GetEntityById(Id);
        }

        public async Task<List<Produto>> List()
        {
            return await _IProduct.List();
        }

        public async Task Update(Produto Objeto)
        {
            await _IProduct.Update(Objeto);
        }

        public async Task<List<Produto>> ListarProdutoComEstoque()
        {
            return await _IServiceProduct.ListarProdutoComEstoque();
        }

       
    }
}
