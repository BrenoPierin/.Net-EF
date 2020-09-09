using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pedidos.Domains
{
    public class Produto
    {
        [Key]

        public Guid Id { get; set; }
        public string NomeProduto { get; set; }
        public float Preco { get; set; }

        public Produto()
        {

            Id = Guid.NewGuid();
        }
    }
}
