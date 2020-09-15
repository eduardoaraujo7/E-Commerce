using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServicoCompraUsuario : IServiceCompraUsuario
    {
        public ServicoCompraUsuario()
        {

        }
        public Task<CompraUsuario> CarrinhoCompras(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<CompraUsuario> ProdutosComprados(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
