using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceProduct
{
    public interface IProduct : IGeneric<Produto>
    {
        Task<List<Produto>> ListarProdutoUsuario(string userId);

        Task<List<Produto>> ListarProdutos(Expression<Func<Produto, bool>> exProduto);

        Task<List<Produto>> ListarProdutoCarrinhoUsuario(string userId);

        Task<Produto> ObterProdutoCarrinho(int idProdutoCarrinho);  
    }
}
