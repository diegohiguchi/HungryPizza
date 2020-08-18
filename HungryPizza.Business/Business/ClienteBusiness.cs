using HungryPizza.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizza.Business.Business
{
    public class ClienteBusiness
    {
        public bool ValidarExisteCliente(Guid id, Guid clienteId)
        {
            if (id != clienteId) return false;

            return true;
        }

        public bool ValidarEnderecoCliente(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Endereco)) return false;

            return true;
        }
    }
}
