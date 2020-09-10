using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Pedidos.Domains;
using API_Pedidos.Interfaces;
using API_Pedidos.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Pedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidosController()
        {
            _pedidoRepository = new PedidoRepository();
        }

        [HttpGet]
        public List<Pedido> Get()
        {
            return _pedidoRepository.Listar();
        }

        [HttpGet("{id}")]
        public Pedido Get(Guid id)
        {
            return _pedidoRepository.BuscarPorId(id);
        }

        [HttpPost]
        public void Post(Pedido pedido)
        {
            _pedidoRepository.Adicionar(pedido);
        }

        [HttpPut("{id}")]
        public void Put(Guid Id, Pedido pedido)
        {
            pedido.Id = Id;
            _pedidoRepository.Editar(pedido);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid Id)
        {
            _pedidoRepository.Excluir(Id);
        }
    }
}

