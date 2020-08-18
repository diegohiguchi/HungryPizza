using HungryPizza.Business.Models;
using System;
using System.Collections.Generic;

namespace HungryPizza.Models
{
    public class Pedido : Entity
    {
        public Pedido()
        {
            Data = DateTime.Now;
        }

        public Guid ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorTotal { get; set; }
        public virtual IEnumerable<PedidoPizza> PedidoPizzas { get; set; }
    }
}
