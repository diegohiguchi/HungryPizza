using FluentValidation;
using HungryPizza.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizza.Business.Models.Validations
{
    public class PedidoValidation : AbstractValidator<Pedido>
    {
        public PedidoValidation()
        {
            RuleFor(c => c.ClienteId)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}
