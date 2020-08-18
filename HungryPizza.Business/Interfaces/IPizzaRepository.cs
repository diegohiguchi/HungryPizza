using HungryPizza.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HungryPizza.Business.Interfaces
{
    public interface IPizzaRepository : IRepository<Pizza>
    {
        Task<Pizza> ObterPizza(Guid id);
        Task<IEnumerable<Pizza>> ObterTodasPizzas();
    }
}
