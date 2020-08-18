using HungryPizza.Business.Models;
using HungryPizza.Business.Validacoes;
using HungryPizza.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace HungryPizza.Tests
{
    public class PedidoTest
    {
        private readonly PedidoBusiness _pedidoBusiness;
        private readonly Pedido _pedido;
        private readonly PedidoPizza _pedidoPizza;
        private readonly Pizza _pizza;
        public PedidoTest()
        {
            _pedidoBusiness = new PedidoBusiness();
            _pedido = new Pedido();
            _pedidoPizza = new PedidoPizza();
            _pizza = new Pizza();
        }

        [Fact]
        public void DeveValidarPedidoComNoMinimoUmaPizza()
        {
            //Arrange
            _pedidoPizza.PedidoId = Guid.NewGuid();
            _pedidoPizza.PizzaId = Guid.NewGuid();
            _pedidoPizza.TipoPizza = TipoPizza.Inteira;
            var listaPedidoPizzas = new List<PedidoPizza>();
            listaPedidoPizzas.Add(_pedidoPizza);
            _pedido.PedidoPizzas = listaPedidoPizzas;

            //Act
            var retorno = _pedidoBusiness.ValidarQuantidadeMinimaPedido(_pedido);

            //Assert
            Assert.True(retorno);
        }

        [Fact]
        public void DeveValidarPedidoComNoMaximoDezPizzas()
        {
            //Arrange
            var listaPedidoPizzas = new List<PedidoPizza>();

            for (int i = 0; i < 10; i++)
            {
                _pedidoPizza.PedidoId = Guid.NewGuid();
                _pedidoPizza.PizzaId = Guid.NewGuid();
                _pedidoPizza.TipoPizza = TipoPizza.Inteira;
                listaPedidoPizzas.Add(_pedidoPizza);
            }
            
            _pedido.PedidoPizzas = listaPedidoPizzas;

            //Act
            var retorno = _pedidoBusiness.ValidarQuantidadeMaximaPedido(_pedido);

            //Assert
            Assert.True(retorno);
        }

        [Fact]
        public void DeveValidarQuantidadeDeSaboresDaPizza()
        {
            //Arrange
            var listaPedidoPizzas = new List<PedidoPizza>();

            for (int i = 0; i < 2; i++)
            {
                _pedidoPizza.TipoPizza = TipoPizza.Meia;
                listaPedidoPizzas.Add(_pedidoPizza);
            }

            _pedido.PedidoPizzas = listaPedidoPizzas;

            //Act
            var retorno = _pedidoBusiness.ValidarQuantidadeSaboresPizza(_pedido);

            //Assert
            Assert.True(retorno);
        }

        [Fact]
        public void DeveValidarCalculoDeSaboresDaPizza()
        {
            //Arrange
            var listaPedidoPizzas = new List<PedidoPizza>();
            _pizza.Valor = 50;

            for (int i = 0; i < 2; i++)
            {
                _pedidoPizza.PizzaId = Guid.NewGuid();
                _pedidoPizza.TipoPizza = TipoPizza.Meia;
                _pedidoPizza.Pizza = _pizza;
                listaPedidoPizzas.Add(_pedidoPizza);
            }

            _pedido.PedidoPizzas = listaPedidoPizzas;

            //Act
            var retorno = _pedidoBusiness.CalcularValorDoisSaboresPizza(_pedido);

            //Assert
            var valorEsperado = 50;
            Assert.Equal(valorEsperado, retorno);
        }
    }
}
