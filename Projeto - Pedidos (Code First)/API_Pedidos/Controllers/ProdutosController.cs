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
    public class ProdutosController : ControllerBase
    {
        private readonly IProduto _produtoRepository;

        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        [HttpGet]
        public List<Produto> Get()
        {
            return _produtoRepository.Listar();
        }

        [HttpGet("{id}")]
        public Produto Get(Guid id)
        {
            return _produtoRepository.BuscarPorId(id);
        }

        [HttpPost]
        public void Post(Produto produto)
        {
            _produtoRepository.Adicionar(produto);
        }

        [HttpPut("{id}")]
        public void Put(Guid Id, Produto produto)
        {
            produto.Id = Id;
            _produtoRepository.Editar(produto);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid Id)
        {
            _produtoRepository.Excluir(Id);
        }
    }
}
