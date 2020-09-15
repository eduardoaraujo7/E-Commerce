﻿using Entities.Entities.Enums;
using Entities.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entities
{
    [Table("TB_COMPRA_USUARIO")]
    public class CompraUsuario : Notifies
    {
        [Column("CUS_ID")]
        [Display(Name = "Codigo")]
        public int Id { get; set; }

        [Display(Name = "Produto")]
        [ForeignKey("TB_PRODUTO")]
        [Column(Order = 1)]
        public int IdProduto { get; set; }
        public virtual Produto Produto { get; set; }

        [Column("CUS_ESTADO")]
        [Display(Name = "Estado")]
        public EnumEstadoCompra Estado { get; set; }

        [Column("CUS_QTD")]
        [Display(Name = "Quantidade")]
        public int QtdCompra { get; set; }

        [Display(Name = "USUARIO")]
        [ForeignKey("ApplicationUser")]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        [Display(Name ="Quantidade Total")]
        public int QunatidadeProdutos { get; set; }

        [NotMapped]
        [Display(Name ="Valor Total")]
        public decimal ValorTotal { get; set; }

        [NotMapped]
        [Display(Name ="Endereço de Entrega")]
        public string EnderecoCompleto { get; set; }

        [NotMapped]
        public List<Produto> ListaProdutos { get; set; }
    }
}
