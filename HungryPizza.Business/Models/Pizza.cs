using HungryPizza.Business.Models;
using System;
using System.Collections.Generic;

namespace HungryPizza.Models
{
    public class Pizza : Entity
    {
        public string Sabor { get; set; }
        public decimal Valor { get; set; }
        public virtual IEnumerable<PedidoPizza> PedidoPizzas { get; set; }
    }
}
