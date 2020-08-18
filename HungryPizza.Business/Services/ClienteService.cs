using HungryPizza.Business.Business;
using HungryPizza.Business.Interfaces;
using HungryPizza.Business.Models.Validations;
using HungryPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizza.Business.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ClienteBusiness _clienteBusiness;

        public ClienteService(IClienteRepository clienteRepository,
            INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
            _clienteBusiness = new ClienteBusiness();
        }

        public async Task<bool> Adicionar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return false;

            if (_clienteRepository.Buscar(c => c.Id == cliente.Id).Result.Any())
            {
                Notificar("Já existe cliente com esse id.");
                return false;
            }

            await _clienteRepository.Adicionar(cliente);
            return true;
        }

        public async Task<bool> Atualizar(Guid id, Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return false;

            if (!_clienteBusiness.ValidarExisteCliente(id, cliente.Id))
            {
                Notificar("O id do cliente informado não é o mesmo que foi passado na query.");
                return false;
            }

            if (!_clienteRepository.Buscar(c => c.Id == cliente.Id).Result.Any())
            {
                Notificar("Cliente não encontrado.");
                return false;
            }

            await _clienteRepository.Atualizar(cliente);
            return true;
        }

        public void Dispose()
        {
            _clienteRepository?.Dispose();
        }

        public async Task Remover(Guid id)
        {
            await _clienteRepository.Remover(id);
        }
    }
}
