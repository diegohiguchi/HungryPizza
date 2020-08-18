using HungryPizza.Business.Interfaces;
using HungryPizza.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace HungryPizza.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Cliente> ObterCliente(Guid id)
        {
            return await Db.Clientes.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
