using HungryPizza.Business.Interfaces;
using HungryPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HungryPizza.Tests
{
    public class ClienteRepositoryFake : IClienteRepository
    {
        List<Cliente> listaCliente = new List<Cliente>();

        public Task Adicionar(Cliente entity)
        {
            listaCliente.Add(entity);

            return Task.CompletedTask;
        }

        public Task Atualizar(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cliente>> Buscar(Expression<Func<Cliente, bool>> predicate)
        {
            var cliente = listaCliente.Where(predicate.Compile());

            return Task.FromResult(cliente);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> ObterCliente(Guid id)
        {
            var cliente = listaCliente.Where(c => c.Id == id).FirstOrDefault();

            return Task.FromResult(cliente);
        }

        public Task<Cliente> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cliente>> ObterTodos()
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
    }
}