using HungryPizza.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizza.ViewModels
{
    public class PedidoPizzaViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid PedidoId { get; set; }
        public Guid PizzaId { get; set; }
        public PizzaViewModel Pizza { get; set; }
        public TipoPizza TipoPizza { get; set; }
    }
}
