using HungryPizza.Business.Models;
using HungryPizza.Business.Notificacoes;
using HungryPizza.Business.Services;
using HungryPizza.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HungryPizza.Tests
{
    public class CadastraPedidoTest
    {
        [Fact]
        public void DadoPedidoComInformacaoValidaDeveIncluirNoBanco()
        {
            //Arrange
            var pedidoId = Guid.NewGuid();
            var clienteId = Guid.NewGuid();
            var cliente = new Cliente()
            {
                Id = clienteId,
                Nome = "Carlos",
                Endereco = "Rua Teste",
            };

            var pedidoPizza = new PedidoPizza();
            var listaPedidoPizzas = new List<PedidoPizza>();
            var pizza = new Pizza();
            pizza.Valor = 50;

            for (int i = 0; i < 2; i++)
            {
                pedidoPizza.TipoPizza = TipoPizza.Meia;
                pedidoPizza.Pizza = pizza;
                listaPedidoPizzas.Add(pedidoPizza);
            }

            var pedido = new Pedido()
            {
                Id = pedidoId,
                ClienteId = clienteId,
                PedidoPizzas = listaPedidoPizzas
            };
            
            var pedidoRepositoryFake = new PedidoRepositoryFake();
            var clienteRepositoryFake = new ClienteRepositoryFake();
            var notificador = new Notificador();
            var clienteService = new ClienteService(clienteRepositoryFake, notificador);
            var pedidoService = new PedidoService(pedidoRepositoryFake, clienteRepositoryFake, notificador);

            //Act
            var retornoCliente = clienteService.Adicionar(cliente);
            var retornoPedido = pedidoService.Adicionar(pedido);

            //Assert
            var cadastroPedido = pedidoRepositoryFake.ObterPorId(pedidoId);
            Assert.NotNull(cadastroPedido.Result);
        }

    }
}
