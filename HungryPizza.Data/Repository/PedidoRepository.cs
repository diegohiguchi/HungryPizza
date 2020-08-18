using HungryPizza.Business.Interfaces;
using HungryPizza.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizza.Data.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Pedido> ObterPedido(Guid id)
        {
            return await Db.Pedidos.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Pedido>> ObterTodos()
        {
            return await Db.Pedidos.AsNoTracking()
                .Include(p => p.Cliente)
                .Include(p => p.PedidoPizzas)
                    .ThenInclude(c => c.Pizza)
                .ToListAsync();
        }

        public async Task<IEnumerable<Pedido>> ObterPedidosPorCliente(Guid clienteId)
        {
            return await Db.Pedidos.AsNoTracking()
                .Include(p => p.Cliente)
                .Include(p => p.PedidoPizzas)
                    .ThenInclude(c => c.Pizza)
                .Where(c => c.ClienteId == clienteId)
                .ToListAsync();
        }
    }
}
