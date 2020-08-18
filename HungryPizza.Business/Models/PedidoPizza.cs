using HungryPizza.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizza.Business.Models
{
    public class PedidoPizza : Entity
    {
        public Guid PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }
        public Guid PizzaId { get; set; }
        public virtual Pizza Pizza{ get; set; }
        public TipoPizza TipoPizza { get; set; }
    }

    public enum TipoPizza
    {
        Inteira = 1,
        Meia = 2
    }
}
