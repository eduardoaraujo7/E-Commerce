﻿using Domain.Interfaces.InterfaceCompraUsuario;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Entities.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServicoCompraUsuario : IServiceCompraUsuario
    {
        private readonly ICompraUsuario _ICompraUsuario;
        public ServicoCompraUsuario(ICompraUsuario ICompraUsuario)
        {
            _ICompraUsuario = ICompraUsuario;
        }
        public async Task<CompraUsuario> CarrinhoCompras(string userId)
        {
            return await _ICompraUsuario.ProdutosCompradosPorEstado(userId, EnumEstadoCompra.Produto_Carrinho);
        }

        public async Task<CompraUsuario> ProdutosComprados(string userId)
        {
            return await _ICompraUsuario.ProdutosCompradosPorEstado(userId, EnumEstadoCompra.Produto_Comprando);
        }
    }
}
