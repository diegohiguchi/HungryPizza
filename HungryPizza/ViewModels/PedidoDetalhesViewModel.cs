using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizza.ViewModels
{
    public class PedidoDetalhesViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid ClienteId { get; set; }
        public ClienteViewModel Cliente { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal ValorTotal { get; set; }

        public IEnumerable<PedidoPizzaDetalhesViewModel> PedidoPizzas { get; set; }
    }
}
