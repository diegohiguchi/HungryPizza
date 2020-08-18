using HungryPizza.Business.Interfaces;
using HungryPizza.Business.Models.Validations;
using HungryPizza.Business.Validacoes;
using HungryPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizza.Business.Services
{
    public class PedidoService : BaseService, IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly PedidoBusiness _pedidoBusiness;

        public PedidoService(IPedidoRepository pedidoRepository,
            IClienteRepository clienteRepository,
            INotificador notificador) : base(notificador)
        {
            _pedidoRepository = pedidoRepository;
            _clienteRepository = clienteRepository;
            _pedidoBusiness = new PedidoBusiness();
        }

        public async Task<bool> Adicionar(Pedido pedido)
        {
            if (!ExecutarValidacao(new PedidoValidation(), pedido)) return false;

            if (!_clienteRepository.Buscar(c => c.Id == pedido.ClienteId).Result.Any())
            {
                Notificar("O cliente informado não foi encontrado.");
                return false;
            }

            if(!_pedidoBusiness.ValidarQuantidadeMaximaPedido(pedido))
            {
                Notificar("Informe pelo menos menos uma pizza.");
                return false;
            }

            if (!_pedidoBusiness.ValidarQuantidadeSaboresPizza(pedido))
            {
                Notificar("Cada pizza pode ter até dois sabores.");
                return false;
            }

            pedido.ValorTotal = _pedidoBusiness.CalcularValorUmSaborPizza(pedido) + 
                _pedidoBusiness.CalcularValorDoisSaboresPizza(pedido);

            await _pedidoRepository.Adicionar(pedido);
            return true;
        }

        public async Task Atualizar(Pedido pedido)
        {
            if (!ExecutarValidacao(new PedidoValidation(), pedido)) return;

            await _pedidoRepository.Atualizar(pedido);
        }

        public void Dispose()
        {
            _pedidoRepository?.Dispose();
        }

        public async Task Remover(Guid id)
        {
            await _pedidoRepository.Remover(id);
        }
    }
}
