using HungryPizza.Business.Models;
using HungryPizza.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HungryPizza.Business.Interfaces
{
    public interface IPedidoPizzaRepository : IRepository<PedidoPizza>
    {
        Task<IEnumerable<PedidoPizza>> ObterPedidosPizzaPorCLiente(Guid clienteId);
    }
}
