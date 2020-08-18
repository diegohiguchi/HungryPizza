using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizza.ViewModels
{
    public class PizzaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Sabor { get; set; }
        public decimal Valor { get; set; }
    }
}
