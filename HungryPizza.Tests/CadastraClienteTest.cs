using HungryPizza.Business.Notificacoes;
using HungryPizza.Business.Services;
using HungryPizza.Data;
using HungryPizza.Data.Repository;
using HungryPizza.Models;
using Microsoft.EntityFrameworkCore;
using System;
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

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("DbHungryPizzaContext")
                .Options;
            var contexto = new ApplicationDbContext(options);
            var clienteRepository = new ClienteRepository(contexto);

            var notificador = new Notificador();
            var clienteService = new ClienteService(clienteRepository, notificador);

            //Act
            var retorno = clienteService.Adicionar(cliente);

            //Assert
            var cadastroCliente = clienteRepository.ObterCliente(clienteId);
            Assert.NotNull(cadastroCliente.Result);
        }

    }
}
