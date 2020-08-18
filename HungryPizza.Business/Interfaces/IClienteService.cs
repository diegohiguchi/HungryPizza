using HungryPizza.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizza.Business.Interfaces
{
    public interface IClienteService : IDisposable
    {
        Task<bool> Adicionar(Cliente cliente);
        Task<bool> Atualizar(Guid id, Cliente cliente);
        Task Remover(Guid id);
    }
}
