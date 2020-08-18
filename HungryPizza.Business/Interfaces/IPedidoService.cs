using HungryPizza.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizza.Business.Interfaces
{
    public interface IPedidoService : IDisposable
    {
        Task<bool> Adicionar(Pedido pedido);
        Task Atualizar(Pedido pedido);
        Task Remover(Guid id);
    }
}
