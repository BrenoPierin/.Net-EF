using API_Pedidos.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pedidos.Interfaces
{
    interface IPedidoRepository 
    {
        List<Pedido> Listar();
        Pedido BuscarPorId(Guid Id);
        void Adicionar(Pedido pedido);
        void Editar(Pedido pedido);
        void Excluir(Guid Id);    
    }
}
