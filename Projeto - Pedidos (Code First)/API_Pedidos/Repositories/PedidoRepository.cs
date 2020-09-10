using API_Pedidos.Contexts;
using API_Pedidos.Domains;
using API_Pedidos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pedidos.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContext ctx;

        public PedidoRepository()
        {
            ctx = new PedidoContext();

        }
        public void Adicionar(Pedido pedido)
        {
            try
            {
                ctx.Pedidos.Add(pedido);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Pedido BuscarPorId(Guid Id)
        {
            try
            {
                return ctx.Pedidos.FirstOrDefault(a => a.Id == Id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Pedido pedido)
        {
            try
            {
                Pedido pedidoTemp = BuscarPorId(pedido.Id);

                if (pedidoTemp == null)
                    throw new Exception("Pedido não encontrado");

                pedidoTemp.Status = pedido.Status;
                pedidoTemp.OrderDate = pedido.OrderDate;

                ctx.Pedidos.Update(pedidoTemp);

                ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Excluir(Guid Id)
        {
            try
            {
                Pedido pedido = BuscarPorId(Id);

                if (pedido == null)
                    throw new Exception("Pedido não encontrado");

                ctx.Pedidos.Remove(pedido);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Pedido> Listar()
        {
            try
            {
                return ctx.Pedidos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
