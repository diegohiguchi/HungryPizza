using HungryPizza.Business.Interfaces;
using HungryPizza.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizza.Data.Repository
{
    public class PizzaRepository : Repository<Pizza>, IPizzaRepository
    {
        public PizzaRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Pizza> ObterPizza(Guid id)
        {
            return await Db.Pizzas.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Pizza>> ObterTodasPizzas()
        {
            return await Db.Pizzas.AsNoTracking().OrderBy(p => p.Sabor).ToListAsync();
        }
    }
}
