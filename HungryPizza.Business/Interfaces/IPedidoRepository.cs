using HungryPizza.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HungryPizza.Business.Interfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<IEnumerable<Pedido>> ObterTodos();
        Task<IEnumerable<Pedido>> ObterPedidosPorCliente(Guid clienteId);
    }
}
