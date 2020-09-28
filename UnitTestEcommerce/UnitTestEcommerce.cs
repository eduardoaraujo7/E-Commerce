using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
using Entities.Entities;
using Infrastructure.Repository.Repositories;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTestEcommerce
{
    [TestClass]
    public class UnitTestEcommerce

    {
        [TestMethod]
        public async Task AddProdutoComSucesso()
        {
            try
            {

            IProduct _IProduct = new RepositoryProduct();
            IServiceProduct _IServiceProduct = new ServiceProduct(_IProduct);
            var produto = new Produto
            {
                Descricao = string.Concat("Descrição Test DDD", DateTime.Now.ToString()),
                QtdEstoque = 10,
                Nome = string.Concat("Nome Test DDD", DateTime.Now.ToString()),
                Valor = 10,
                UserId = "7c6eaaf0-55b8-46f3-b333-06fb24b19c9c"
            };
            await _IServiceProduct.AddProduct(produto);

            Assert.IsFalse(produto.Notitycoes.Any());

            }
            catch (Exception)
            {

                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task AddProdutoComValidacaoCampoObrigatorio()
        {
            try
            {

                IProduct _IProduct = new RepositoryProduct();
                IServiceProduct _IServiceProduct = new ServiceProduct(_IProduct);
                var produto = new Produto
                {
                   
                };
                await _IServiceProduct.AddProduct(produto);

                Assert.IsTrue(produto.Notitycoes.Any());

            }
            catch (Exception)
            {

                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task ListaProdutoUsuario()
        {
            try
            {

                IProduct _IProduct = new RepositoryProduct();

                var listaProdutods = await _IProduct.ListarProdutoUsuario("7c6eaaf0-55b8-46f3-b333-06fb24b19c9c");
              
                Assert.IsTrue(listaProdutods.Any());

            }
            catch (Exception)
            {

                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task GetEntityById()
        {
            try
            {

                IProduct _IProduct = new RepositoryProduct();

                var listaProdutos = await _IProduct.ListarProdutoUsuario("7c6eaaf0-55b8-46f3-b333-06fb24b19c9c");

                var produto = await _IProduct.GetEntityById(listaProdutos.LastOrDefault().Id);

                Assert.IsTrue(produto != null);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task Delete()
        {
            try
            {

                IProduct _IProduct = new RepositoryProduct();

                var listaProdutos = await _IProduct.ListarProdutoUsuario("7c6eaaf0-55b8-46f3-b333-06fb24b19c9c");

                var UltimoProduto = listaProdutos.LastOrDefault();

                await _IProduct.Delete(UltimoProduto);

                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}
