using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HungryPizza.Business.Interfaces;
using HungryPizza.Models;
using HungryPizza.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HungryPizza.Controllers
{
    [Route("api/v1/pedidos")]
    [ApiController]
    public class PedidosController : MainController
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoService _pedidoService;
        private readonly IMapper _mapper;

        public PedidosController(IPedidoRepository pedidoRepository,
            IPedidoService pedidoService,
            INotificador notificador, IMapper mapper) : base(notificador)
        {
            _pedidoRepository = pedidoRepository;
            _pedidoService = pedidoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PedidoDetalhesViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<PedidoDetalhesViewModel>>(await _pedidoRepository.ObterTodos());
        }

        [HttpGet("cliente/{id:guid}")]
        public async Task<IEnumerable<PedidoDetalhesViewModel>> ObterPorClienteId(Guid id)
        {
            var pedido = await ObterPedidosPorCliente(id);

            return pedido;
        }

        [HttpPost]
        public async Task<ActionResult<PedidoViewModel>> Adicionar(PedidoViewModel pedidoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _pedidoService.Adicionar(_mapper.Map<Pedido>(pedidoViewModel));

            return CustomResponse(pedidoViewModel);
        }

        private async Task<IEnumerable<PedidoDetalhesViewModel>> ObterPedidosPorCliente(Guid id)
        {
            return _mapper.Map<IEnumerable<PedidoDetalhesViewModel>>(await _pedidoRepository.ObterPedidosPorCliente(id));
        }
    }
}
