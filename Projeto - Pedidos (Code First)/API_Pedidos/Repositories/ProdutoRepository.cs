using API_Pedidos.Contexts;
using API_Pedidos.Domains;
using API_Pedidos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pedidos.Repositories
{
    public class ProdutoRepository : IProduto
    {
        private readonly PedidoContext ctx;

        public ProdutoRepository()
        {
            ctx = new PedidoContext();

        }

        public void Adicionar(Produto produto)
        {
            try
            {
                ctx.Produtos.Add(produto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Produto BuscarPorId(Guid Id)
        {
            try
            {
               return ctx.Produtos.FirstOrDefault(c => c.Id == Id);
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Produto> BuscarPorNome(string nome)
        {
            try
            {
                List<Produto> produtos = ctx.Produtos.Where(c => c.NomeProduto.Contains(nome)).ToList();
                return produtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Produto produto)
        {
            try
            {
                Produto produtoTemp = BuscarPorId(produto.Id);

                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado");

                produtoTemp.NomeProduto = produto.NomeProduto;
                produtoTemp.Preco = produto.Preco;

                ctx.Produtos.Update(produtoTemp);
                
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
                Produto produto = BuscarPorId(Id);

                if (produto == null)
                    throw new Exception("Produto não encontrado");

                ctx.Produtos.Remove(produto);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<Produto> Listar()
        {
            try
            {
                return ctx.Produtos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

    }
}
