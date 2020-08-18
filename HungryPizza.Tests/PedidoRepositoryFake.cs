using HungryPizza.Business.Interfaces;
using HungryPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HungryPizza.Tests
{
    public class PedidoRepositoryFake : IPedidoRepository
    {

        List<Pedido> listaPedido = new List<Pedido>();

        public Task Adicionar(Pedido entity)
        {
            listaPedido.Add(entity);

            return Task.CompletedTask;
        }

        public Task Atualizar(Pedido entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pedido>> Buscar(Expression<Func<Pedido, bool>> predicate)
        {
            var pedido = listaPedido.Where(predicate.Compile());

            return Task.FromResult(pedido);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pedido>> ObterPedidosPorCliente(Guid clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<Pedido> ObterPorId(Guid id)
        {
            var pedido = listaPedido.Where(c => c.Id == id).FirstOrDefault();

            return Task.FromResult(pedido);
        }

        public Task<IEnumerable<Pedido>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }

        Task<List<Pedido>> IRepository<Pedido>.ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}