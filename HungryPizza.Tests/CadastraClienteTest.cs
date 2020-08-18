using HungryPizza.Business.Notificacoes;
using HungryPizza.Business.Services;
using HungryPizza.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HungryPizza.Tests
{
    public class CadastraClienteTest
    {
        [Fact]
        public void DadoClienteComInformacaoValidaDeveIncluirNoBanco()
        {
            //Arrange
            var clienteId = Guid.NewGuid();
            var cliente = new Cliente()
            {
                Id = clienteId,
                Nome = "Carlos",
                Endereco = "Rua Teste",
            };

            var clienteRepositoryFake = new ClienteRepositoryFake();
            var notificador = new Notificador();
            var clienteService = new ClienteService(clienteRepositoryFake, notificador);

            //Act
            var retorno = clienteService.Adicionar(cliente);

            //Assert
            var cadastroCliente = clienteRepositoryFake.ObterCliente(clienteId);
            Assert.NotNull(cadastroCliente.Result);
        }

    }
}
