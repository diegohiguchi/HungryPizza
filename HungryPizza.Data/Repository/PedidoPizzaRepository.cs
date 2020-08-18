using HungryPizza.Business.Interfaces;
using HungryPizza.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizza.Data.Repository
{
    public class PedidoPizzaRepository : Repository<PedidoPizza>, IPedidoPizzaRepository
    {
        public PedidoPizzaRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<PedidoPizza>> ObterPedidosPizzaPorCLiente(Guid clienteId)
        {
            return await Db.PedidoPizzas.AsNoTracking()
                .Include(p => p.Pedido)
                .Include(p => p.Pedido.Cliente)
                .Include(p => p.Pizza)
                .Where(c => c.Pedido.ClienteId == clienteId)
                .ToListAsync();
        }
    }
}
