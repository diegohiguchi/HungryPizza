using HungryPizza.Business.Models;
using HungryPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HungryPizza.Business.Validacoes
{
    public class PedidoBusiness
    {
        public bool ValidarQuantidadeMinimaPedido(Pedido pedido)
        {
            if (!pedido.PedidoPizzas.Any()) return false;

            return true;
        }

        public bool ValidarQuantidadeMaximaPedido(Pedido pedido)
        {
            if (pedido.PedidoPizzas.Count() > 10) return false;

            return true;
        }

        public bool ValidarQuantidadeSaboresPizza(Pedido pedido)
        {
            var quantidadeSaboresPizza = pedido.PedidoPizzas.Where(x => x.TipoPizza == TipoPizza.Meia).Count() % 2;

            if (quantidadeSaboresPizza != 0) return false;

            return true;
        }

        public decimal CalcularValorDoisSaboresPizza(Pedido pedido)
        {
            var pizzasDoisSabores = pedido.PedidoPizzas.Where(x => x.TipoPizza == TipoPizza.Meia);
            decimal valor = 0;

            foreach (var pizzaDoisSabores in pizzasDoisSabores)
                valor += pizzaDoisSabores.Pizza.Valor / 2;

            return valor;
        }

        public decimal CalcularValorUmSaborPizza(Pedido pedido)
        {
            var pizzasUmSabor = pedido.PedidoPizzas.Where(x => x.TipoPizza == TipoPizza.Inteira);
            decimal valor = 0;

            foreach (var pizzaUmSabor in pizzasUmSabor)
                valor += pizzaUmSabor.Pizza.Valor;

            return valor;
        }
    }
}
