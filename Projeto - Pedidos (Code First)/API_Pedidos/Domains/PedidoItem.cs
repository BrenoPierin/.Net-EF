using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pedidos.Domains
{
    public class PedidoItem
    {
        [Key]
        public Guid Id { get; set; }
        public Guid IdPedido { get; set; }
        [ForeignKey("idPedido")]
        public Pedido Pedido { get; set; }

        public Guid IdProduto { get; set; }
        [ForeignKey("idProduto")]
        public Produto Produto { get; set; }

        public PedidoItem()
        {
            Id = Guid.NewGuid();
        }
    }
}
