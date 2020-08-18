using HungryPizza.Business.Business;
using HungryPizza.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HungryPizza.Tests
{
    public class ClienteTeste
    {
        private readonly ClienteBusiness _clienteBusiness;
        private readonly Cliente _cliente;

        public ClienteTeste()
        {
            _clienteBusiness = new ClienteBusiness();
            _cliente = new Cliente();
        }

        [Fact]
        public void DeveValidarSeExisteCliente()
        {
            //Arrange
            var guid = Guid.NewGuid();
            _cliente.Id = guid;
            var clienteId = guid;

            //Act
            var retorno = _clienteBusiness.ValidarExisteCliente(_cliente.Id, clienteId);

            //Assert
            Assert.True(retorno);
        }

        [Fact]
        public void DeveValidarEnderecoDoCliente()
        {
            //Arrange
            _cliente.Endereco = "Rua Tal";

            //Act
            var retorno = _clienteBusiness.ValidarEnderecoCliente(_cliente);

            //Assert
            Assert.True(retorno);
        }
    }
}
