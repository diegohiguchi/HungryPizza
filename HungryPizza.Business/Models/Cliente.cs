using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizza.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public virtual IEnumerable<Pedido> Pedidos { get; set; }
    }
}
